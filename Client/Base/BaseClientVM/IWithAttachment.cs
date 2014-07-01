using System.Collections.Generic;
using DBEntity;

namespace Client.Base.BaseClientVM
{
    /// <summary>
    /// The VM has attachments should implement this interface
    /// In the attachment pop-dialog, the attachment VM will operate 
    /// the parent VM through this interface
    /// </summary>
    public interface IWithAttachment
    {
        /// <summary>
        /// All the Attachments of current document
        /// </summary>
        List<Attachment> Attachments { get; set; }

        /// <summary>
        /// New added attachments of current document
        /// </summary>
        List<Attachment> NewAddedAttachments { get; set; }

        /// <summary>
        /// Deleted Attachments during Editing
        /// </summary>
        List<Attachment> DeletedAttachments { get; set; } 

        /// <summary>
        /// Add the attachment to the attachment list in the parent VM
        /// </summary>
        /// <param name="attachment"></param>
        void AddAttachment(Attachment attachment);

        /// <summary>
        /// Remove the attachment by the reference
        /// </summary>
        /// <param name="attachment"></param>
        void RemoveAttachment(Attachment attachment);

        /// <summary>
        /// Remove attachment by its id
        /// </summary>
        /// <param name="id"></param>
        void RemoveAttachment(int id);
    }
}
