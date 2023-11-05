using System.Globalization;
using System.Text;
using System.Text.Json;
using CsvHelper;
using CsvHelper.Configuration;
using Drag_Static_Site.Models;
using Microsoft.JSInterop;

namespace Drag_Static_Site.Services
{
    public class TheGridPageService
    {
        public Task<string> GetJsonStringForGridData(GridData gridData)
        {
            var dataWithHeaders = new List<GridItem> {gridData.Header};
            dataWithHeaders.AddRange(gridData.GridItems);
            var json = JsonSerializer.Serialize(dataWithHeaders);
            return Task.FromResult(json);
        }

        public Task<MemoryStream> ConvertStringToMemoryStream(string data)
        {
            var bytes        = Encoding.Unicode.GetBytes(data);
            var memoryStream = new MemoryStream(bytes);
            return Task.FromResult(memoryStream);
        }

        public Task<string> GetCsvStringForGridData(GridData gridData)
        {
            var dataWithHeaders = new List<GridItem> {gridData.Header};
            dataWithHeaders.AddRange(gridData.GridItems);
            string stringBuffer;
            using (var writer = new StringWriter())
            {
                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);
                csvConfig.Encoding = Encoding.UTF32;
                csvConfig.HasHeaderRecord = true;
                csvConfig.ShouldSkipRecord = row => row.Row.CurrentIndex == 0;
                using (var csvWriter = new CsvWriter(writer, csvConfig))
                {
                    csvWriter.WriteRecord(dataWithHeaders.First());
                    csvWriter.NextRecord();
                    foreach (var dataWithHeader in dataWithHeaders.Skip(1))
                    {
                        csvWriter.WriteRecord(dataWithHeader);
                        csvWriter.NextRecord();
                    }
                    stringBuffer = writer.ToString();
                }
            }

            return Task.FromResult(stringBuffer);
        }
    }
}
