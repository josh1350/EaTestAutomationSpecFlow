using AutoFixture.Xunit2;
using EaApplicationTest.Fixture;
using EaApplicationTest.Pages;
using EaFramework.Config;
using EaFramework.Driver;
using Microsoft.Playwright;
using EaApplicationTest.Models;

namespace EaApplicationTest
{
    public class Tests
    {
        private readonly ITestFixtureBase _testFixtureBase;
        private readonly TestSettings _testSettings;
        private readonly IProductPage _productPage;
        private readonly IProductListPage _productListPage;

        public Tests(ITestFixtureBase testFixtureBase, TestSettings testSettings,
            IPlaywrightDriverInitializer playwrightDriverInitializer,
            IProductPage productPage,
            IProductListPage productListPage)
        {
            _testSettings = testSettings;
            _productPage = productPage;
            _productListPage = productListPage;
            _testFixtureBase = testFixtureBase;
        }

        [Fact]
        public async Task Test2()
        {
            var product = new Product()
            {
                Name = "Test Product",
                Description = "Test Product",
                Price = 1000,
                ProductType = ProductType.CPU,
            };

            await _productListPage.CreateProductAsync();
            await _productPage.CreateProduct(product);

            await _productListPage.ClickProductFromList(product.Name);

            var element = _productListPage.IsProductCreated(product.Name);
            await Assertions.Expect(element).ToBeVisibleAsync();
        }


        // [Fact]
        // public async Task LoginTest()
        // {
        //     await page.GotoAsync(_testSettings.ApplicationUrl);
        //     await page.ClickAsync("text=Login");
        //     await page.GetByLabel("UserName").FillAsync("admin");
        //     await page.GetByLabel("Password").FillAsync("password");
        //
        //     await page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = "Log in" }).ClickAsync();
        //
        //     await page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Employee List" }).ClickAsync();
        // }

        [Theory, AutoData]
        public async Task TestWithAutFixtureData(Product product)
        {
            //Arrange
            await _testFixtureBase.NavigateToUrl();
            await _productListPage.CreateProductAsync();
            await _productPage.CreateProduct(product);
            await _productPage.ClickCreate();


            //Act
            await _productListPage.ClickProductFromList(product.Name);

            //Assert
            var element = _productListPage.IsProductCreated(product.Name);
            await Assertions.Expect(element).ToBeVisibleAsync();
        }
    }
}