using System;

namespace Medical.Forms.Interfaces
{
    public interface IContainerProvider
    {
        /// <summary>
        /// Gets the component by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        Object GetComponentByKey(string key);
    }
}
