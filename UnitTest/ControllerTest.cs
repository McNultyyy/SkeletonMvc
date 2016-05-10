using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Extension;
using Mapper;
using Moq;
using NUnit.Framework;
using Web;
using Web.Controllers;

namespace UnitTest
{
    [TestFixture]
    public class ControllerTest
    {
        private static Mock<HttpContextBase> MockedHttpContext(string url)
        {
            var mockHttpContext = new Mock<HttpContextBase>();
            var mockResponse = new Mock<HttpResponseBase>();

            mockHttpContext.Setup(x => x.Response).Returns(mockResponse.Object);

            return mockHttpContext;
        }

        [Test]
        public void TestAllControllerActions()
        {
            AutoMapperConfig.RegisterMapping();

            var mockHttpContext = MockedHttpContext("").Object;

            var allTypes = typeof(MvcApplication).Assembly.GetExportedTypes();

            //Generic types are not allowed as they are only used for inheritance.
            IEnumerable<Type> controllerTypes = allTypes
                .Where(type => type.IsSubclassOf(typeof(Controller)) && !type.IsGenericType);


            foreach (var controllerType in controllerTypes)
            {
                var controllerConstructors = controllerType.GetConstructors();
                var ctor = controllerConstructors.OrderByDescending(x => x.GetParameters().Length).FirstOrDefault();

                var controllerParamInfos = ctor.GetParameters();

                var dependencies = new List<object>();
                foreach (var parameter in controllerParamInfos)
                {
                    var paramType = parameter.ParameterType;

                    //var realDependency = IoC.GetConfiguredContainer().Resolve(paramType);
                    var fakeDependency = paramType.DynamicMock();

                    dependencies.Add(fakeDependency);
                }
                var controller = Activator.CreateInstance(controllerType, dependencies.ToArray());

                var controllerProperties = controllerType.GetProperties();
                foreach (var controllerProperty in controllerProperties)
                {
                    if (controllerProperty.Name == nameof(ControllerContext))
                        controllerProperty.SetValue(controller, new ControllerContext { HttpContext = mockHttpContext }, null);
                }


                var actions = controllerType.GetMethods().Where(x => x.ReturnType == typeof(ActionResult));
                foreach (var action in actions)
                {
                    var methodParamInfos = action.GetParameters();
                    var methodParams = new List<object>();

                    foreach (var parameter in methodParamInfos)
                    {
                        var paramType = parameter.ParameterType;
                        var obj = Activator.CreateInstance(paramType);

                        if (obj == null)
                        {
                            var underlyingParamType = Nullable.GetUnderlyingType(paramType);
                            var underlyingObj = Activator.CreateInstance(underlyingParamType);
                            methodParams.Add(underlyingObj);
                        }
                        else
                        {
                            methodParams.Add(obj);
                        }
                    }

                    var input = methodParamInfos.Any() ? methodParams.ToArray() : null;

                    var result = action.Invoke(controller, input);
                    Assert.IsInstanceOf<ActionResult>(result);

                    var paramsString = string.Join(", ",
                        methodParamInfos.Select(x => x.ParameterType.FormattedName() + " " + x.Name));

                    Console.WriteLine("Tested {0}.{1}({2})", controllerType.Name, action.Name, paramsString);
                }
            }
        }
    }
}
