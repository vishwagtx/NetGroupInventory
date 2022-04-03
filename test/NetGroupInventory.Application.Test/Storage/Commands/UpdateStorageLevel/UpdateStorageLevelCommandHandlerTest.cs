using Moq;
using NetGroupInventory.Application.Common.Dtos;
using NetGroupInventory.Application.Interfaces;
using NetGroupInventory.Application.Storage.Commands.UpdateStorageLevel;
using NetGroupInventory.Domain.Stoarge;
using Xunit;

namespace NetGroupInventory.Application.Test.Storage.Commands.UpdateStorageLevel
{
    public class UpdateStorageLevelCommandHandlerTest
    {
        readonly Mock<IUnitOfWork> uow;
        readonly Mock<IUserIdentity> identity;
        readonly UpdateStorageLevelCommandHandler handler;
        readonly string storageLevel = "test > level > 1";
        readonly string userId = "user_id_1";

        public UpdateStorageLevelCommandHandlerTest()
        {
            uow = new Mock<IUnitOfWork>();
            identity = new Mock<IUserIdentity>();
            handler = new UpdateStorageLevelCommandHandler(uow.Object, identity.Object);

            identity.Setup(s => s.Identifier).Returns(userId);
        }

        [Fact]
        public async Task Should_Return_ErrorMessage_When_StorageLevel_Is_Existing_In_Database()
        {
            int storageLevelId = 1;
            uow.Setup(s => s.StorageLevels.HasLevel(storageLevel, userId, storageLevelId)).Returns(true);

            var response = await handler.Handle(new UpdateStorageLevelCommand
            {
                Id = 1,
                Level = storageLevel,
            }, It.IsAny<CancellationToken>());

            Assert.False(response.Succeed);
            Assert.Equal("Storage level is already existing in the database", response.Errors?.FirstOrDefault());
        }

        [Fact]
        public async Task Should_Be_Succced_When_StorageLevel_IsNot_Existing_In_Database()
        {
            int storageLevelId = 1;

            uow.Setup(s => s.StorageLevels.HasLevel(storageLevel, userId, storageLevelId)).Returns(false);
            uow.Setup(s => s.StorageLevels.GetById(storageLevelId)).ReturnsAsync(new StorageLevel
            {
                Id = storageLevelId,
                Level = storageLevel,
            });

            var response = await handler.Handle(new UpdateStorageLevelCommand
            {
                Id = storageLevelId,
                Level = storageLevel,
                Description = "New Test"
            }, It.IsAny<CancellationToken>());

            Assert.True(response.Succeed);
            uow.Verify(v => v.SaveAsync(), Times.Once);
        }
    }
}
