using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibraryCommon
{
    public class MediaDTO
    {
        private int _mediaId;
        private string _mediaType;
        private string _mediaName;

        public int MediaId { get => _mediaId; }
        public string MediaType { get { return _mediaType; } set { _mediaType = value; } }
        public string MediaName { get { return _mediaName; } set { _mediaName = value; } }


        public MediaDTO(int mediaId, string mediaType, string mediaName)
        {
            _mediaId = mediaId;
            _mediaType = mediaType;
            _mediaName = mediaName;
        }
    }
}
