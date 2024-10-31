using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Azure.Data.Tables;
using Azure;
using WeeklyMenu;

namespace IBAS_kantine.Pages;

public class IndexModel : PageModel
{  
    public List<WeeklyMenuDTO> Menu { get; set; } = new List<WeeklyMenuDTO>();
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        string tablename = "WebAppCloudComputing";
        string connectionString = "DefaultEndpointsProtocol=https;EndpointSuffix=core.windows.net;AccountName=ibasbikeproduction3;AccountKey=Rus9dFjRrtl/RdIkZagETFEZFDyXLuOHAAbyHjpE06LdDkJuAwl/opbRc5LWrkr0rQL3EQzKsy7j+AStc+waVw==;BlobEndpoint=https://ibasbikeproduction3.blob.core.windows.net/;FileEndpoint=https://ibasbikeproduction3.file.core.windows.net/;QueueEndpoint=https://ibasbikeproduction3.queue.core.windows.net/;TableEndpoint=https://ibasbikeproduction3.table.core.windows.net/";
        TableClient tableClient = new TableClient(connectionString, tablename);
        Pageable<TableEntity> entities = tableClient.Query<TableEntity>();
        
        foreach (TableEntity entity in entities)
        {
            var dto = new WeeklyMenuDTO {
                UgeDag = entity.RowKey,
                VarmRet = entity.PartitionKey,
                KoldRet = entity["KoldRet"].ToString()
            };
            Menu.Add(dto);
        }
    }
}
