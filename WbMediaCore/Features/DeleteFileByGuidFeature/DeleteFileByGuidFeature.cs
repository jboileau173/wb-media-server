using System.Transactions;
using WbMediaCore.Messages;
using WbMediaCore.Services;

namespace WbMediaCore.Features.DeleteFileByGuidFeature
{
    public class DeleteFileByGuidFeature : IFeature<DeleteFileByGuidRequest, DeleteFileByGuidResponse>
    {
        public DeleteFileByGuidResponse Result { get; set; }

        private IFileService _fileService { get; set; }

        public DeleteFileByGuidFeature(IFileService fileService)
        {
            _fileService = fileService;
        }

        public void Execute(DeleteFileByGuidRequest request)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                _fileService.DeleteByGuid(request.guid);
                _fileService.Save();

                scope.Complete();
            }

            Result = new DeleteFileByGuidResponse();
        }
    }
}
