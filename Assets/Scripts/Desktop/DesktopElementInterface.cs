﻿public interface DesktopElementInterface
{
    string getElementName();
    void setElementName(string name);

    int getElementType();
    void setElementType(int type);


    void performOnClickAction();

    DesktopController DesktopController { get; set; }
    DesktopPosition DesktopPosition { get; set; }

}
