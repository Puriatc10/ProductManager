using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProductManagerTest.Api.Controllers;
using ProductManagerTest.Application.Commands;
using ProductManagerTest.Application.Dto_s;
using ProductManagerTest.UnitTest.FakeData;
using Xunit;

namespace ProductManagerTest.UnitTest.Systems.Controllers
{
    public class ProductControllerTest
    {

        //[Fact]
        //public async Task AddProduct_Should_Return_OkResult()
        //{
        //    var mediatormock = new Mock<IMediator>();
        //    var sendermock = new Mock<ISender>();
        //    var controller = new ProductController(mediatormock.Object);

        //    var fake = ProductFake.AddProductCommands.FirstOrDefault();


        //    sendermock.Setup(x => x.Send<AddProductCommand>(fake)).ReturnsAsync(new AddProductDto());

        //    var result = await controller.AddProduct();

        //    Assert.NotNull(result);
        //    Assert.IsType<OkResult>(result);
        //}
    }
}
