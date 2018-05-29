/*	
	Gamma Spectator - Monitoring application for Gamma Analyzer sessions
    Copyright (C) 2018  Norwegian Radiation Protection Authority

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
// Authors: Dag robole,

using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace crash
{
    // Class used to store application settings
    [Serializable()]
    public class GASettings
    {
        public GASettings() 
        {
            LastHostname = "";
            LastUploadHostname = "";
            LastUploadUsername = "";
            LastUploadPassword = "";
            DisplayLocalTime = true;
        }

        // List of ROI definitions
        [XmlArray("ROIList")]
        public List<ROIData> ROIList = new List<ROIData>();

        // Last IP address used
        public string LastHostname;

        // Last upload hostname
        public string LastUploadHostname;

        // Last upload credentials
        public string LastUploadUsername;
        public string LastUploadPassword;

        // Display dates using local time
        public bool DisplayLocalTime;
    }
}
