using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Provides the skeleton to an algorithm that can be overridden by other class

/**********************************************
VideoPlayer: Abstract class
MkvVideo: Concrete class
MP4Video: Concrete Clas

**********************************************/
namespace TemplateMethod
{
    //'AbstractClass' abstract class
    abstract class VideoPlayer
    {
        //default steps 
        public void LoadFile()
        {
            Console.WriteLine("Video File loaded");
        }
        // steps that will be overidden by subclass
        public abstract void DecodeVideoFormat();
        // default step
        public void StartPlay()
        {
            Console.WriteLine("Video File starts playing");
        }
        //'Template Method'
        public void PlayVideo()
        {
            this.LoadFile();
            this.DecodeVideoFormat();
            this.StartPlay();
        }

    }
    //'ConcreteClass'- concrete class
    class MP4Video : VideoPlayer
    {
        public override void DecodeVideoFormat()
        {
            Console.WriteLine("Video file is processed with MP4 Decoder");
        }
    }

    //'ConcreteClass' - concrete class
    class MkvVideo : VideoPlayer
    {
        public override void DecodeVideoFormat()
        {
            Console.WriteLine("Video file is processed with Mkv Decoder");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------- Video Player - MP4 video--------------");
            VideoPlayer fileExporter = new MP4Video();
            fileExporter.PlayVideo();
            Console.WriteLine("----------------Video Player - MKV video---------------");
            fileExporter = new MkvVideo();
            fileExporter.PlayVideo();

            Console.ReadLine();
        }
    }
}
