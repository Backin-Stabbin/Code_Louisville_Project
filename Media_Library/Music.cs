using System;

namespace Treehouse.MediaLibrary {

    class Music : MediaType {
        public readonly string Name;
        public readonly string Album;

        public Music (string name, string album) {
            Name = name;
            Album = album;
        }

    }
}