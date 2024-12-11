using TechTalk.SpecFlow;

namespace EaSpecflowTests.Steps
{
    [Binding]
    public sealed class ProductSteps
    {
      

        private readonly ScenarioContext _scenarioContext;

        public ProductSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }


       

        [GivenAttribute(@"I click the Product menu")]
        public void GivenIClickTheProductMenu()
        {
            ScenarioContext.StepIsPending();
        }

        [GivenAttribute(@"I click the ""(.*)"" link")]
        public void GivenIClickTheLink(string create)
        {
            ScenarioContext.StepIsPending();
        }

        [WhenAttribute(@"I click the Details link of the newly created product")]
        public void WhenIClickTheDetailsLinkOfTheNewlyCreatedProduct()
        {
            ScenarioContext.StepIsPending();
        }

        [ThenAttribute(@"I see all the product details are created as expected")]
        public void ThenISeeAllTheProductDetailsAreCreatedAsExpected()
        {
            ScenarioContext.StepIsPending();
        }
    }
}