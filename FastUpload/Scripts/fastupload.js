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
        index: function () {
            var $ul = $("#upload ul");

            $("#drop a").click(function () {
                $(this).parent().find('input').trigger("click");
            });

            $("#upload").fileupload({
                dropZone: $("#drop"),
                add: function (e, data) {
                    var file = data.files[0];
                    
                    if (file.size > 10240) {
                        alert("O tamanho do arquivo " + file.name + " é maior que o tamanho máximo permitido");
                    } else {
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

                        $template.find("span").click(function () {
                            if ($template.hasClass("working")) {
                                jqXHR.abort();
                            }

                            $template.fadeOut(function () {
                                $template.remove();
                            });
                        });
                        var jqXHR = data.submit();
                    }
                },
                progress: function (e, data) {
                    var progress = parseInt(data.loaded / data.total * 100, 10);
                    data.context.find("input").val(progress).change();
                    if (progress == 100) {
                        data.context.removeClass("working");
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