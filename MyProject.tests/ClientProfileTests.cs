using Dapper;
using MyProject.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using Xunit;

namespace MyProject.tests
{
  public class ClientProfileTests
  {
    [Fact]
    public async void GetAllClientProfiles()
    {
      //Arrange
      var httpClient = new HttpClient();
      httpClient.BaseAddress = new Uri("http://localhost:64267/");

      //collecting profiles from the database
      var totalClientProfiles = 0;
      await using (var connection = new SqlConnection("Server=GamingDb5;Database=Bingo;User Id=sa;Password=!@#$%A1;"))
      {
        var sql = "select count() from dbo.tb_ClientProfile";
        totalClientProfiles = await connection.QueryFirstAsync<int>(sql);
      }

      //Act
      var responseObject = await httpClient.GetAsync("api/clientprofile");
      var responseBody = await responseObject.Content.ReadAsStringAsync();
      var responseProfiles = JsonConvert.DeserializeObject<IEnumerable<ClientProfileController.ClientProfile>>(responseBody);

      //Assert -> Checking the count on both the database and API response matches.
      Assert.Equal(totalClientProfiles, responseProfiles.Count());
    }
  }
}
