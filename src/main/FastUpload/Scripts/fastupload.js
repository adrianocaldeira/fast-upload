var fastUpload = {
    formatFileSize: function (bytes) {
        if (typeof bytes !== "number") {
            return "";
        }

        if (bytes >= 1000000000) {
            return (bytes / 1000000000).toFixed(2) + " GB";
        }

        if (bytes >= 1000000) {
            return (bytes / 1000000).toFixed(2) + " MB";
        }

        return (bytes / 1000).toFixed(2) + " KB";
    },
    uploads: {
        index: function (settings) {
            var $ul = $("#upload ul");
            var files = [];

            $("#drop a").click(function () {
                $(this).parent().find('input').trigger("click");
            });

            $("#upload").fileupload({
                dropZone: $("#drop"),
                add: function (e, data) {
                    var file = data.files[0];
                    var getExtension = function () {
                        return (/[.]/.exec(file.name)) ? /[^.]+$/.exec(file.name)[0] : undefined;
                    };
                    var validateFile = function () {
                        var message = "";
                        var valid = true;
                        var extension = getExtension();

                        if (file.size > parseInt(settings.limitFileSize, 10)) {
                            message = String.format(settings.message.fileSizeExceed, file.name, fastUpload.formatFileSize(parseInt(settings.limitFileSize, 10)));
                            valid = false;
                        }
                        
                        if (extension === undefined || (settings.extensions !== "*" && $.inArray(extension, settings.extensions.split(";")) === -1)) {
                            message = String.format(settings.message.extensionInvalid, file.name, settings.extensions);
                            valid = false;
                        }

                        return {
                            "message": message,
                            "valid": valid
                        };
                    };
                    var validade = validateFile();
                    
                    if (validade.valid) {
                        var $template = $("<li></li>").addClass("working")
                            .append(
                                $("<input/>").attr({
                                    "type": "text",
                                    "value": "0",
                                    "data-width": "48",
                                    "data-height": "48",
                                    "data-fgColor": "#0788a5",
                                    "data-readOnly": "1",
                                    "data-bgColor": "#3e4043"
                                }))
                            .append($("<p></p>"))
                            .append($("<span></span>"));

                        $template.find("p").text(file.name).append("<i>" + fastUpload.formatFileSize(file.size) + "</i>");

                        data.context = $template.appendTo($ul);

                        $template.find("input").knob();

                        $template.find("span").click(function() {
                            if ($template.hasClass("working")) {
                                jqXHR.abort();
                            }

                            $template.fadeOut(function() {
                                $template.remove();
                            });
                        });

                        var jqXHR = data.submit();
                    } else {
                        var $templateInvalid = $("<li></li>").addClass("working")
                            .append($("<p></p>").addClass("invalid"))
                            .append($("<span></span>"));

                        $templateInvalid.find("p").text(validade.message).append("<i>" + fastUpload.formatFileSize(file.size) + "</i>");

                        data.context = $templateInvalid.appendTo($ul);

                        $templateInvalid.find("span").click(function () {
                            $templateInvalid.fadeOut(function () {
                                $templateInvalid.remove();
                            });
                        });
                    }
                },
                progress: function (e, data) {
                    var progress = parseInt(data.loaded / data.total * 100, 10);
                    data.context.find("input").val(progress).change();
                    if (progress == 100) {
                        data.context.removeClass("working");
                    }
                },
                done: function (e, data) {
                    files.push(data.result[0]);
                },
                stop: function () {
                    if (window.parent) {
                        parent.postMessage({ type: "success", data: files }, settings.targetOrigin);
                    }
                },
                fail: function (e, data) {
                    data.context.addClass("error");
                }
            });

            $(document).on("drop dragover", function (e) {
                e.preventDefault();
            });
        }
    }
};