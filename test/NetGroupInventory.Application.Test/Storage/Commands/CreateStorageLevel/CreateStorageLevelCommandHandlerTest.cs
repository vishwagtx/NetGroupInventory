using Moq;
using NetGroupInventory.Application.Common.Dtos;
using NetGroupInventory.Application.Interfaces;
using NetGroupInventory.Application.Storage.Commands.CreateStorageLevel;
using NetGroupInventory.Domain.Stoarge;
using Xunit;

namespace NetGroupInventory.Application.Test.Storage.Commands.CreateStorageLevel
{
    public class CreateStorageLevelCommandHandlerTest
    {
        readonly Mock<IUnitOfWork> uow;
        readonly Mock<IUserIdentity> identity;
        readonly CreateStorageLevelCommandHandler handler;
        readonly string storageLevel = "test > level > 1";
        readonly string userId = "user_id_1";

        public CreateStorageLevelCommandHandlerTest()
        {
            uow = new Mock<IUnitOfWork>();
            identity = new Mock<IUserIdentity>();
            handler = new CreateStorageLevelCommandHandler(uow.Object, identity.Object);

            identity.Setup(s => s.Identifier).Returns(userId);
        }

        [Fact]
        public async Task ShouldReturnErrorMessageWhenStorageLevelIsExistingInDatabase()
        {
            uow.Setup(s => s.StorageLevels.HasLevel(storageLevel, userId)).Returns(true);

            var response = await handler.Handle(new CreateStorageLevelCommand
            {
                Level = storageLevel,
            }, It.IsAny<CancellationToken>());

            Assert.False(response.Succeed);
            Assert.Equal("Storage level is already existing in the database", response.Errors?.FirstOrDefault());
        }

        [Fact]
        public async Task ShouldBeSucccedEWhenStorageLevelIsNotExistingInDatabase()
        {
            uow.Setup(s => s.StorageLevels.HasLevel(storageLevel, userId)).Returns(false);

            var response = await handler.Handle(new CreateStorageLevelCommand
            {
                Level = storageLevel,
                Description = "Test"
            }, It.IsAny<CancellationToken>());

            Assert.True(response.Succeed);
            uow.Verify(v => v.StorageLevels.Create(It.IsAny<StorageLevel>()), Times.Once);
            uow.Verify(v => v.SaveAsync(), Times.Once);
        }
    }
}
