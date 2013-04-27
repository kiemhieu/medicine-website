using Medical.Forms.Entities;

namespace Medical.Forms.Interfaces
{
    public interface IMessageManager
    {
        /// <summary>
        /// Gets the formated message by ID.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="param">The param.</param>
        /// <returns></returns>
        SystemMessage GetMessageByID(string id, params object[] param);
    }

}
