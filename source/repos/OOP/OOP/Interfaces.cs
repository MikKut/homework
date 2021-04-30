using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OOP
{
    public interface IContent
    {
        string Content { get; set; }
    }
    public interface IResolution
    {
        string Resolution { get; set; }

    }
    public interface ILength
    {
        string Length { get; set; }

    }
    public interface ITypeOfFile
    {
        string Type { get; set; }

    }
    public interface ISize
    {
        public string Size { get; set; }
    }
    public interface IName
    {
        string Name { get; set; }

    }
    public interface IExtension
    {
        string Extension { get; set; }
    }
}
