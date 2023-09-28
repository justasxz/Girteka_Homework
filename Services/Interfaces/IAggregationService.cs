using Girteka_Homework.Data.Models;

namespace Girteka_Homework.Services.Interfaces
{
    public interface IAggregationService
    {

        List<Electronic_Data> GetAggregatedData();
        //declaration for unit tests
        List<Electronic_Data> ReadCsvs();

    }
}
