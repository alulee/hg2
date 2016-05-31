using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using HGenealogy.Data;
using LinqToExcel;

namespace HGenealogy.Infrastructure.Helpers
{
    public class ImportDataHelper
    {
        /// <summary>
        /// 檢查匯入的 Excel 資料.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="importZipCodes">The import zip codes.</param>
        /// <returns></returns>
        public CheckResult CheckImportData(
            string fileName,
            List<TaiwanZipCode> importZipCodes)
        {
            var result = new CheckResult();

            var targetFile = new FileInfo(fileName);

            if (!targetFile.Exists)
            {
                result.ID = Guid.NewGuid();
                result.Success = false;
                result.ErrorCount = 0;
                result.ErrorMessage = "匯入的資料檔案不存在";
                return result;
            }

            var excelFile = new ExcelQueryFactory(fileName);

            //欄位對映
            excelFile.AddMapping<TaiwanZipCode>(x => x.ID, "ID");
            excelFile.AddMapping<TaiwanZipCode>(x => x.Zip, "Zip");
            excelFile.AddMapping<TaiwanZipCode>(x => x.CityName, "CityName");
            excelFile.AddMapping<TaiwanZipCode>(x => x.Town, "Town");
            excelFile.AddMapping<TaiwanZipCode>(x => x.Sequence, "Sequence");

            //SheetName
            var excelContent = excelFile.Worksheet<TaiwanZipCode>("臺灣郵遞區號");

            int errorCount = 0;
            int rowIndex = 1;
            var importErrorMessages = new List<string>();

            //檢查資料
            foreach (var row in excelContent)
            {
                var errorMessage = new StringBuilder();
                var zipCode = new TaiwanZipCode();

                zipCode.ID = row.ID;
                zipCode.Sequence = row.Sequence;
                zipCode.Zip = row.Zip;
                zipCode.CreateDate = DateTime.Now;

                //CityName
                if (string.IsNullOrWhiteSpace(row.CityName))
                {
                    errorMessage.Append("縣市名稱 - 不可空白. ");
                }
                zipCode.CityName = row.CityName;

                //Town
                if (string.IsNullOrWhiteSpace(row.Town))
                {
                    errorMessage.Append("鄉鎮市區名稱 - 不可空白. ");
                }
                zipCode.Town = row.Town;

                //=============================================================================
                if (errorMessage.Length > 0)
                {
                    errorCount += 1;
                    importErrorMessages.Add(string.Format(
                        "第 {0} 列資料發現錯誤：{1}{2}",
                        rowIndex,
                        errorMessage,
                        "<br/>"));
                }
                importZipCodes.Add(zipCode);
                rowIndex += 1;
            }

            try
            {
                result.ID = Guid.NewGuid();
                result.Success = errorCount.Equals(0);
                result.RowCount = importZipCodes.Count;
                result.ErrorCount = errorCount;

                string allErrorMessage = string.Empty;

                foreach (var message in importErrorMessages)
                {
                    allErrorMessage += message;
                }

                result.ErrorMessage = allErrorMessage;

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        /// <summary>
        /// Saves the import data.
        /// </summary>
        /// <param name="importZipCodes">The import zip codes.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void SaveImportData(IEnumerable<TaiwanZipCode> importZipCodes)
        {
            try
            {
                //先砍掉全部資料
                using (var db = new hDatabaseEntities())
                {
                    foreach (var item in db.TaiwanZipCodes.OrderBy(x => x.ID))
                    {
                        db.TaiwanZipCodes.Remove(item);
                    }
                    db.SaveChanges();
                }

                //再把匯入的資料給存到資料庫
                using (var db = new hDatabaseEntities())
                {
                    foreach (var item in importZipCodes)
                    {
                        db.TaiwanZipCodes.Add(item);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        /// <summary>
        /// 檢查匯入的族譜 Excel 資料.
        /// </summary>        
        public CheckResult CheckImportGeneData(
            string fileName,
            List<Family> importFamilies)
        {
            var result = new CheckResult();

            var targetFile = new FileInfo(fileName);

            if (!targetFile.Exists)
            {
                result.ID = Guid.NewGuid();
                result.Success = false;
                result.ErrorCount = 0;
                result.ErrorMessage = "匯入的資料檔案不存在";
                return result;
            }

            var excelFile = new ExcelQueryFactory(fileName);
            
            //欄位對映
            //編號	曾祖	祖	父	母	本人	住址	E-MAIL	配偶	代別	電話	工作	備註	子女	子女	子女	子女	子女		
			excelFile.AddMapping<Family>(x => x.FNo, "編號");
            excelFile.AddMapping<Family>(x => x.GGFatherName, "曾祖");
            excelFile.AddMapping<Family>(x => x.GFatherName, "祖");
            excelFile.AddMapping<Family>(x => x.FatherName, "父");
            excelFile.AddMapping<Family>(x => x.FName, "本人");
            excelFile.AddMapping<Family>(x => x.Address, "住址");
            excelFile.AddMapping<Family>(x => x.Email, "E-MAIL");
            excelFile.AddMapping<Family>(x => x.Mate, "配偶");
            excelFile.AddMapping<Family>(x => x.GenerationNo, "代別");
            excelFile.AddMapping<Family>(x => x.Phone1, "電話");
            excelFile.AddMapping<Family>(x => x.Job, "工作");
            excelFile.AddMapping<Family>(x => x.Notes, "備註");
            //excelFile.AddMapping<Family>(x => x.Childrens, "子女");

            //SheetName
            var excelContent = excelFile.Worksheet<Family>("工作表1");

            int errorCount = 0;
            int rowIndex = 1;
            var importErrorMessages = new List<string>();

            //檢查資料
            using (hDatabaseEntities db = new hDatabaseEntities())
            {
                foreach (var row in excelContent)
                {
                    var errorMessage = new StringBuilder();
                    var family = new Family();

                    family.FNo = "G01-" + row.FNo;
                    family.GId = "G01";
                    family.GGFatherName = row.GGFatherName;
                    family.GFatherName = row.GFatherName;
                    family.FatherName = row.FatherName;
                    family.FName = row.FName;
                    family.Address = row.Address;
                    family.Email = row.Email;
                    family.Mate = row.Mate;
                    family.GenerationNo = row.GenerationNo;
                    family.Phone1 = row.Phone1;
                    family.Job = row.Job;

                    // 檢查是否重複
                    var chkfamily = db.Families.Where(x => x.FName == family.FName && x.FatherName == family.FatherName)
                                            .FirstOrDefault();
                    if (chkfamily != null)
                    {
                        errorMessage.AppendFormat("名字為 {0} 的資料已存在，不重新匯入，請檢查!", family.FName);
                    }
                    // 檢查ID重複
                    var chkID = db.Families.Where(x => x.FNo == family.FNo)
                                            .FirstOrDefault();
                    if (chkID != null)
                    {
                        errorMessage.AppendFormat("編號為 {0} 的資料已存在，不重新匯入，請檢查!", family.FNo);
                    }

                    if (family.GenerationNo == null || family.GenerationNo <= 0)
                    {
                        errorMessage.AppendFormat("名字為 {0} 的世代別錯誤，不匯入，請檢查!", family.FName);
                    }

                    //=============================================================================
                    if (errorMessage.Length > 0)
                    {
                        errorCount += 1;
                        importErrorMessages.Add(string.Format(
                            "第 {0} 列資料發現錯誤：{1}{2}",
                            rowIndex,
                            errorMessage,
                            "<br/>"));

                        continue;
                    }
                    importFamilies.Add(family);
                    rowIndex += 1;
                }
            }

            try
            {
                result.ID = Guid.NewGuid();
                result.Success = errorCount.Equals(0);
                result.RowCount = importFamilies.Count;
                result.ErrorCount = errorCount;

                string allErrorMessage = string.Empty;

                foreach (var message in importErrorMessages)
                {
                    allErrorMessage += message;
                }

                result.ErrorMessage = allErrorMessage;

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public CheckResult SaveImportGeneData(IEnumerable<Family> importFamilies)
        {
            var saveErrorMessages = new List<string>();
            var errorMessage = new StringBuilder();
            string allErrorMessage = "";
            Family currentFamily = null;

            //把匯入的資料給存到資料庫
            using (var db = new hDatabaseEntities())
            {
                foreach (var item in importFamilies)
                {
                    try
                    {
                        errorMessage.Clear();
                        currentFamily = item;
                        db.Families.Add(item);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        db.Families.Remove(item);                        
                        errorMessage.AppendFormat("編號 {0} 名字為 {1} 的世系資料匯入錯誤，請檢查!", currentFamily.FNo, currentFamily.FName);
                        return new CheckResult { Success = false, ErrorMessage = errorMessage.ToString() }; 
                    }
                    if (errorMessage.Length > 0)
                    {
                        saveErrorMessages.Add(string.Format(
                            "{0}{1}",
                            errorMessage,
                            "<br/>"));
                    }
                }
                foreach (var message in saveErrorMessages)
                {
                    allErrorMessage += message;
                }

            }
            return new CheckResult { Success = true, ErrorMessage = allErrorMessage};           
        }

    }
}