using RestSharp;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using System;

namespace APITestAutomation.StepsDefinitions
{
    [Binding]
    public class ManageEnergyOrdersSteps
    {
        private RestClient _client;
        private RestResponse _response;
        private string _token;

        public ManageEnergyOrdersSteps()
        {

            _client = new RestClient("https://your-api-url.com");
        }
         
        private void ExecuteRequest(Method method, string endpoint, object body = null)
        {
            var request = new RestRequest(endpoint, method);

            if (body != null)
            {
                request.AddJsonBody(body);
            }

            _response = _client.Execute(request);

            
        }

        private void AssertResponseStatusCode(int expectedStatusCode)
        {
            Assert.That((int)_response.StatusCode, Is.EqualTo(expectedStatusCode),
                $"Expected status code {expectedStatusCode} but received {(int)_response.StatusCode}");
        }

        private string GetTokenFromResponse()
        {
            var jsonResponse = JObject.Parse(_response.Content);
            return jsonResponse["token"]?.ToString();
        }
      
        private void AssertMessageDisplayed(string expectedMessage)
        {
            Assert.That(_response.Content.Contains(expectedMessage),
                $"Expected message: '{expectedMessage}' but received: '{_response.Content}'");
        }

        [Given(@"that a POST call is made to ENSEK/login resource with a username (.) and a password ""(.)""")]
        public void GivenThatAPOSTCallIsMadeToLoginResource(string username, string password)
        {
            var body = new { username, password };
            ExecuteRequest(Method.Post, "ENSEK/login", body);
        }

        [Given(@"that a POST call is made to ENSEK/reset resource")]
        public void GivenThatAPOSTCallIsMadeToResetResource()
        {
            ExecuteRequest(Method.Post, "ENSEK/reset");
        }

        [Given(@"that a PUT call is made on ENSEK/buy/(.) resource")]
        public void GivenThatAPUTCallIsMadeOnBuyResource(int energyTypeId)
        {
            ExecuteRequest(Method.Put, $"ENSEK/buy/{energyTypeId}");
        }

        [Given(@"that a GET call is made on ENSEK/orders/(.*) resource")]
        public void GivenThatAGETCallIsMadeOnOrdersResource(int orderId)
        {
            ExecuteRequest(Method.Get, $"ENSEK/orders/{orderId}");
        }

        [Then(@"the candidate should get a status code (.*)")]
        public void ThenTheCandidateShouldGetAStatusCode(int expectedStatusCode)
        {
            AssertResponseStatusCode(expectedStatusCode);
        }

        [Then(@"a token should be generated")]
        public void ThenATokenShouldBeGenerated()
        {
            _token = GetTokenFromResponse();
            Assert.That(_token, Is.Not.Null.And.Not.Empty, "Token was not generated.");
        }

        [Then(@"a success message should be displayed")]
        public void ThenASuccessMessageShouldBeDisplayed()
        {
            AssertMessageDisplayed("Success");
        }

        [Then(@"a message ""(.*)"" should be displayed")]
        public void ThenAMessageShouldBeDisplayed(string expectedMessage)
        {
            AssertMessageDisplayed(expectedMessage);
        }

        [Given(@"that a PUT call is made on ENSEK/buy/(.*)/(.*) resource")]
        public void GivenThatAPUTCallIsMadeOnENSEKBuyResource(int energyTypeId, int quantity)
        {
            ExecuteRequest(Method.Put, $"ENSEK/buy/{energyTypeId}/{quantity}");
        }

        [Then(@"details of the order should is displayed")]
        public void ThenDetailsOfTheOrderShouldIsDisplayed(string expectedMessage)
        {
            Assert.That(_response.Content.Contains(expectedMessage),
               $"Expected message: '{expectedMessage}' but received: '{_response.Content}'");
        }
        [Given(@"that a POST call is made to ENSEK/login resource with a username (.*) and a password (.*)")]
        public void GivenThatAPOSTCallIsMadeToENSEKLoginResourceWithAUsernameAndAPassword(string test, string testing)
        {
            ExecuteRequest(Method.Post, "ENSEK/login");
        }

        [Given(@"that a GET call is made on ENSEK/orders resource")]
        public void GivenThatAGETCallIsMadeOnENSEKOrdersResource()
        {
            ExecuteRequest(Method.Get, $"ENSEK/orders");
        }
        [Then(@"a message with details of the order should is displayed")]
        public void ThenAMessageWithDetailsOfTheOrderShouldIsDisplayed(string expectedMessage)
        {
            Assert.That(_response.Content.Contains(expectedMessage), $"Expected message: '{expectedMessage}' but received: '{_response.Content}'");
        }
        [Then(@"details of the orders should be displayed")]
        public void ThenDetailsOfTheOrdersShouldBeDisplayed(string expectedMessage)
        {
            Assert.That(_response.Content.Contains(expectedMessage),
             $"Expected message: '{expectedMessage}' but received: '{_response.Content}'");
        }

        [Then(@"details of the order should be displayed")]
        public void ThenDetailsOfTheOrderShouldBeDisplayed(string expectedMessage)
        {
            Assert.That(_response.Content.Contains(expectedMessage),
             $"Expected message: '{expectedMessage}' but received: '{_response.Content}'");
        }
        [Then(@"""([^""]*)"" should be displayed")]
        public void ThenShouldBeDisplayed(string expectedMessage)
        {
            AssertMessageDisplayed(expectedMessage);
        }

            [Then(@"details all order should be displayed")]
        public void ThenDetailsAllOrderShouldBeDisplayed(string expectedMessage)
        {
            AssertMessageDisplayed(expectedMessage);

        }
    }
}
    

       
        
    
