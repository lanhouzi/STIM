using STIM.WinFormUI.ExtControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace STIM.WinFormUI
{
    public class CreateStimControl
    {
        public CreateStimControl()
        {

        }

        public StimWfTextBox CreateStimWfTextBox(XElement xElement, bool draggable = false)
        {
            StimWfTextBox stimTxt = new StimWfTextBox
            {
                Name = (string)xElement.Attribute("ColumnName"),
                Location = new Point((int)xElement.Attribute("X"), (int)xElement.Attribute("Y")),
                Width = (int)xElement.Attribute("W"),
                Height = (int)xElement.Attribute("H"),
                Visible = (bool)xElement.Attribute("Visible"),
                Enabled = (bool)xElement.Attribute("Enabled"),
                lblFile =
                {
                    Text = (string)xElement.Attribute("ColumnName")
                },
                dataFile =
                {
                    Enabled = (bool)xElement.Attribute("Enabled"),
                    Width = (int)xElement.Element("DataControl").Attribute("W"),
                    Height = (int)xElement.Element("DataControl").Attribute("H")
                }
            };
            return null;
        }
    }
}
