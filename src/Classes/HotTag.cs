﻿using System.Xml;

namespace FlickrNet
{
    /// <summary>
    /// A hot tag. Returned by <see cref="Flickr.TagsGetHotList()"/>.
    /// </summary>
    public sealed class HotTag : IFlickrParsable
    {
        /// <summary>
        /// The tag that is hot.
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// The score for the tag.
        /// </summary>
        public int Score { get; set; }

        #region IFlickrParsable Members

        void IFlickrParsable.Load(XmlReader reader)
        {
            while (reader.MoveToNextAttribute())
            {
                switch (reader.LocalName)
                {
                    case "score":
                        Score = reader.ReadContentAsInt();
                        break;
                }
            }

            reader.Read();

            if (reader.NodeType == XmlNodeType.Text)
                Tag = reader.ReadContentAsString();

            reader.Read();
        }

        #endregion
    }
}