//================================================================================================
/// <reference path="_references.js" /> Ps.如果你要新增給IntelliSense用的js檔案, 請加在該檔案中
//================================================================================================

(function (app) {
    //===========================================================================================
    var current = app.family = {};
    //===========================================================================================

    jQuery.extend(app.family,
    {
        Initialize: function (actionUrls) {
            /// <summary>
            /// 初始化函式
            /// </summary>
            /// <param name="actionUrls"></param>

            jQuery.extend(project.ActionUrls, actionUrls);

            //上傳檔案事件處理
            current.UploadEventHandler();
        },

        UploadEventHandler: function () {
            /// <summary>
            /// 上傳匯入資料
            /// </summary>

            $("#UploadForm").ajaxForm({
                iframe: true,
                dataType: "json",
                success: function (result) {
                    $("#UploadForm").resetForm(); 
                    if (!result.Result) {
                        $('#ResultContent').html(result.Msg);
                        project.ShowMessage("訊息", "檔案上傳及匯入結束，請檢查匯入結果.");
                    }
                    else {
                        $('#ResultContent').html(result.Msg);
                        project.ShowMessage("訊息", "檔案上傳及匯入結束，請檢查匯入結果.");
                    }
                },
                error: function (xhr, textStatus, errorThrown) {
                    $("#UploadForm").resetForm();
                    project.AlertErrorMessage("錯誤", "檔案上傳錯誤");
                }
            });
        }

    });
})
(project);