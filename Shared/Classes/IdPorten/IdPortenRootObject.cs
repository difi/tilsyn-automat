﻿namespace Difi.Sjalvdeklaration.Shared.Classes.IdPorten
{
    public class IdPortenRootObject
    {
        public string access_token { get; set; }

        public string id_token { get; set; }

        public string token_type { get; set; }

        public int expires_in { get; set; }

        public string refresh_token { get; set; }

        public string scope { get; set; }
    }
}
