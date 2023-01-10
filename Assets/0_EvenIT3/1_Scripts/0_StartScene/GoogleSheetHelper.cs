using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class GoogleSheetHelper : MonoBehaviour
{
    /*SheetsService sheetsService = new SheetsService(new BaseClientService.Initializer
    {
        HttpClientInitializer = GetCredentialsFromFile(),
        ApplicationName = "Google-SheetsSample/0.1",
    });

    // The ID of the spreadsheet to retrieve data from.
    string spreadsheetId = "my-spreadsheet-id";  // TODO: Update placeholder value.

    // The A1 notation of the values to retrieve.
    string range = "my-range";  // TODO: Update placeholder value.

    // How values should be represented in the output.
    // The default render option is ValueRenderOption.FORMATTED_VALUE.
    SpreadsheetsResource.ValuesResource.GetRequest.ValueRenderOptionEnum valueRenderOption = (SpreadsheetsResource.ValuesResource.GetRequest.ValueRenderOptionEnum) 0;  // TODO: Update placeholder value.

    // How dates, times, and durations should be represented in the output.
    // This is ignored if value_render_option is
    // FORMATTED_VALUE.
    // The default dateTime render option is [DateTimeRenderOption.SERIAL_NUMBER].
    SpreadsheetsResource.ValuesResource.GetRequest.DateTimeRenderOptionEnum dateTimeRenderOption = (SpreadsheetsResource.ValuesResource.GetRequest.DateTimeRenderOptionEnum) 0;  // TODO: Update placeholder value.

    SpreadsheetsResource.ValuesResource.GetRequest request = sheetsService.Spreadsheets.Values.Get(spreadsheetId, range);
    request.ValueRenderOption = valueRenderOption;
    request.DateTimeRenderOption = dateTimeRenderOption;

    // To execute asynchronously in an async method, replace `request.Execute()` as shown:
    Data.ValueRange response = request.Execute();
    // Data.ValueRange response = await request.ExecuteAsync();

    // TODO: Change code below to process the `response` object:

    private static UserCredential GetCredentialsFromFile()
    {
        GoogleCredential credential;
        using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
        {
            credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
        }
        return credential;
    }*/
}
