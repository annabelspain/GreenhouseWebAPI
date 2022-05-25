using GreenhouseWebAPI.Models;
using GreenhouseWebAPI.Services;
using GreenhouseWebAPI.Data;
using GreenhouseWebAPI.Data.Repositories;
using Xunit;

namespace XUnitTests
{
    public class BasicTests
    {
        [Fact]
        public void Add_1_GreenhouseItem()
        {
            GreenhouseService greenhouseService = new GreenhouseService();
            GreenhouseItem greenhouseItem = new GreenhouseItem();
            greenhouseItem.Plant = "Pothos";

            greenhouseService.Add(greenhouseItem);

            Assert.True(greenhouseService.GetGreenhouseItemCount() == 1);
        }
    }
}