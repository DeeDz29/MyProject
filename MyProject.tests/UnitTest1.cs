using System;
using System.Net.Http;
using Xunit;

namespace MyProject.tests
{
  public class UnitTest1
  {
    [Fact]
    public async void Test1()
    {
      //Arrange
      var httpClient = new HttpClient();
      httpClient.BaseAddress = new Uri("http://localhost:64267");

      //Act
      var responseObject = await httpClient.GetAsync("api/values");
      var responseBody = await responseObject.Content.ReadAsStringAsync();

      //Assert
      Assert.Equal("[\"value1\",\"value2\"]", responseBody);
    }
  }
}
