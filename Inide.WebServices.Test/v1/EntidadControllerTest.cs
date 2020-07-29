using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Flurl.Http.Configuration;
using Flurl.Http.Testing;
using Inide.WebServices.Application.ResponseModels;
using Inide.WebServices.EndPoints.v1;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Inide.WebServices.Test.v1
{
    public sealed class EntidadControllerTest
    {


        public async void DetailsAction_Should_Return_View_For_ExistingDinner() {

            // Arrange
           // var controller = new EntidadController();

            // Act
            //var result = await controller.Get() as EntidadResponse;

            // Assert
          //  Assert.IsType<EntidadResponse>(result);
        }


        [Fact]
        public void Test_Some_Http_Calling_Method() {
            using (var httpTest = new HttpTest())
            {
                httpTest.ShouldHaveCalled("")
                    .WithOAuthBearerToken("")
                    .Times(1);
                    
            }


            using (var httpTest = new HttpTest())
            {
                // Arrange.
                httpTest.RespondWith("OK", 200);
 
                // Act.
               // await CreateTodoAsync();
 
                // Assert.
                httpTest.ShouldHaveCalled("api/todos*")
                    .WithVerb(HttpMethod.Post)
                    .WithContentType("application/json");
            }
        }
    }
}
