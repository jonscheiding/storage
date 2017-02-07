﻿using System.Collections.Generic;
using System.IO;

namespace Storage.Net.Blob
{
   /// <summary>
   /// Generic interface for blob storage implementations
   /// </summary>
   public interface IBlobStorage
   {
      /// <summary>
      /// Returns the list of available blobs
      /// </summary>
      /// <param name="prefix">Blob prefix to filter by. When null returns all blobs.
      /// Cannot be longer than 50 characters.</param>
      /// <returns>List of blob IDs</returns>
      IEnumerable<string> List(string prefix);

      /// <summary>
      /// Deletes a blob by id
      /// </summary>
      /// <param name="id">Blob ID, required.</param>
      /// <exception cref="System.ArgumentNullException">Thrown when ID is null.</exception>
      /// <exception cref="System.ArgumentException">Thrown when ID is too long. Long IDs are the ones longer than 50 characters.</exception>
      void Delete(string id);

      /// <summary>
      /// Uploads a new blob. When a blob with identical name already exists overwrites it.
      /// </summary>
      /// <param name="id">Blob ID, required.</param>
      /// <param name="sourceStream">Source stream to copy from.</param>
      /// <exception cref="System.ArgumentNullException">Thrown when any parameter is null</exception>
      /// <exception cref="System.ArgumentException">Thrown when ID is too long. Long IDs are the ones longer than 50 characters.</exception>
      void UploadFromStream(string id, Stream sourceStream);

      /// <summary>
      /// Downloads blob to a stream
      /// </summary>
      /// <param name="id">Blob ID, required</param>
      /// <param name="targetStream">Target stream to copy to, required</param>
      /// <exception cref="System.ArgumentNullException">Thrown when any parameter is null</exception>
      /// <exception cref="System.ArgumentException">Thrown when ID is too long. Long IDs are the ones longer than 50 characters.</exception>
      /// <exception cref="StorageException">Thrown when blob does not exist, error code set to <see cref="ErrorCode.NotFound"/></exception>
      void DownloadToStream(string id, Stream targetStream);

      // --- consistency checks done up to here -----

      /// <summary>
      /// Opens the stream asynchronously to read on demand.
      /// </summary>
      /// <param name="id">Blob ID</param>
      /// <returns></returns>
      Stream OpenStreamToRead(string id);

      /// <summary>
      /// Checks if a blob exists
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      bool Exists(string id);
   }
}
