//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.Logging;
//using Moq;
//using MVC.BLL.Repositories;
//using Xunit;

//namespace MVC.Test.Services;

//public class RoleServiceTests
//{
//    private readonly Mock<RoleManager<IdentityRole>> _roleManagerMock;
//    private readonly Mock<ILogger<RoleService>> _loggerMock;
//    private readonly RoleService _roleService;

//    public RoleServiceTests()
//    {
//        var store = new Mock<IRoleStore<IdentityRole>>(); // Required by RoleManager
//        _roleManagerMock = new Mock<RoleManager<IdentityRole>>(
//            store.Object, null, null, null, null);
//        _loggerMock = new Mock<ILogger<RoleService>>();

//        _roleService = new RoleService(_roleManagerMock.Object, _loggerMock.Object);
//    }

//    [Fact]
//    public async Task CreateRoleAsync_ShouldReturnSuccess_WhenRoleCreationSucceeds()
//    {
//        // Arrange
//        var roleName = "HRManager";
//        var successResult = IdentityResult.Success;

//        // Act
//        var result = await _roleService.CreateRoleAsync(roleName);

//        // Assert
//        Assert.True(result.Succeeded);
//        _roleManagerMock.Verify(rm => rm.CreateAsync(It.IsAny<IdentityRole>()), Times.Once);
//    }

//    //[Fact]
//    //public async Task CreateRoleAsync_ShouldLogError_WhenRoleCreationFails()
//    //{
//    //    // Arrange
//    //    var roleName = "HRManager";
//    //    var errorResult = IdentityResult.Failed(new IdentityError { Description = "Duplicate role" });

//    //    // Act
//    //    var result = await _roleService.CreateRoleAsync(roleName);

//    //    // Assert
//    //    Assert.False(result.Succeeded);
//    //    _loggerMock.Verify(l => l.Log(
//    //        LogLevel.Warning,
//    //        It.IsAny<EventId>(),
//    //        It.Is<It.IsAnyType>((o, t) => o.ToString().Contains("Duplicate role")),
//    //        null,
//    //        It.IsAny<Func<It.IsAnyType, Exception, string>>()), Times.AtLeastOnce);
//    //}
//}
