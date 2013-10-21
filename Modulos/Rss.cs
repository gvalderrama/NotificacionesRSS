using System;
using System.Collections.Generic;
using System.Text;
//*****************************************************************************************
//                           LICENSE INFORMATION
//*****************************************************************************************
//   PC_RSSReader Version 1.0.0.0
//   A custom Rss Reader
//
//   Copyright (C) 2007  
//   Richard L. McCutchen 
//   Email: richard@psychocoder.net
//   Created: 04OCT07
//
//   This program is free software: you can redistribute it and/or modify
//   it under the terms of the GNU General Public License as published by
//   the Free Software Foundation, either version 3 of the License, or
//   (at your option) any later version.
//
//   This program is distributed in the hope that it will be useful,
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//   GNU General Public License for more details.
//
//   You should have received a copy of the GNU General Public License
//   along with this program.  If not, see <http://www.gnu.org/licenses/>.
//*****************************************************************************************
namespace PC
{
    public class Rss
    {
        /// <summary>
        /// A structure to hold the RSS Feed items
        /// </summary>
        [Serializable]
        public struct Items
        {
            /// <summary>
            /// The publishing date.
            /// </summary>
            public DateTime Date;

            /// <summary>
            /// The title of the feed
            /// </summary>
            public string Title;

            /// <summary>
            /// A description of the content (or the feed itself)
            /// </summary>
            public string Description;

            /// <summary>
            /// The link to the feed
            /// </summary>
            public string Link;
        }
    }
}
