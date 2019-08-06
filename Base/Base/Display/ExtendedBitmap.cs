
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Base.Display
{
  public class ExtendedBitmap : IDisposable, ICloneable
  {
    bool _isDisposed;

    Bitmap _bits;

    Graphics _surface;

    protected PropertyCache Cache;
    bool _isNew;

    bool _isInitialised;


    public Graphics Graphics
    {
      get
      {
        Graphics graphics;
        if (_isInitialised)
        {
          _isNew = false;
          graphics = _surface;
        }
        else if (Initialise())
        {
          _isNew = false;
          graphics = _surface;
        }
        else
          graphics = null;
        return graphics;
      }
    }

    public Bitmap Bitmap
    {
      get
      {
        return !_isInitialised ? (Initialise() ? _bits : null) : _bits;
      }
    }

    bool CanInitialise

    {
      get
      {
        bool flag;
        if (_isDisposed)
          flag = false;
        else if (Cache.Size.Width > 0 & Cache.Size.Height > 0)
          flag = true;
        else if (Cache.Bounds.Width > 0 & Cache.Bounds.Height > 0)
        {
          Cache.Size.Width = Cache.Bounds.Width;
          Cache.Size.Height = Cache.Bounds.Height;
          flag = true;
        }
        else
          flag = false;
        return flag;
      }
    }

    public Size Size
    {
      get
      {
        return _isInitialised ? Cache.Size : new Size();
      }
      set
      {
        if (value.Width == Cache.Size.Width && value.Height == Cache.Size.Height)
          return;
        Cache.Size = value;
        Initialise();
      }
    }

    Region Clip

    {
      get
      {
        return _isInitialised ? Cache.Clip : new Region();
      }
      set
      {
        if (!_isInitialised)
          return;
        _surface.Clip = value;
        Cache.Update(ref _surface);
        _isNew = false;
      }
    }

    public Rectangle ClipRect
    {
      get
      {
        return _isInitialised ? Cache.ClipRect : new Rectangle();
      }
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize( this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!disposing || _isDisposed)
        return;
      _isNew = false;
      _isInitialised = false;
      if (_surface != null)
        _surface.Dispose();
      if (_bits != null)
        _bits.Dispose();
      if (Cache.Clip != null)
        Cache.Clip.Dispose();
      _isDisposed = true;
    }

    public object Clone()
    {
      object obj;
      if (!_isInitialised)
      {
        obj =  new ExtendedBitmap();
      }
      else
      {
        ExtendedBitmap extendedBitmap = new ExtendedBitmap(Size)
        {
          Cache = Cache
        };
        extendedBitmap._surface.DrawImageUnscaled(_bits, new Point(0, 0));
        extendedBitmap.Clip = Clip;
        extendedBitmap._isInitialised = _isInitialised;
        extendedBitmap._isNew = _isNew;
        obj =  extendedBitmap;
      }
      return obj;
    }

    bool Initialise()

    {
      bool flag;
      if (!CanInitialise)
      {
        flag = false;
      }
      else
      {
        if (_surface != null)
          _surface.Dispose();
        if (_bits != null)
          _bits.Dispose();
        _bits = new Bitmap(Cache.Size.Width, Cache.Size.Height, Cache.BitDepth);
        _surface = Graphics.FromImage(_bits);
        Cache.Update(ref _bits);
        _surface.Clip = new Region(Cache.Bounds);
        Cache.Update(ref _surface);
        _isNew = true;
        _isInitialised = true;
        flag = true;
      }
      return flag;
    }

    void Initialise(string fileName)

    {
      if (_surface != null)
        _surface.Dispose();
      if (_bits != null)
        _bits.Dispose();
      if (!File.Exists(fileName))
      {
        Cache = new PropertyCache
        {
          Size = new Size(32, 32)
        };
        Initialise();
      }
      else
      {
        _bits = new Bitmap(fileName);
        _surface = Graphics.FromImage(_bits);
        Cache.Update(ref _bits);
        _surface.Clip = new Region(Cache.Bounds);
        Cache.Update(ref _surface);
        _isNew = true;
        _isInitialised = true;
      }
    }

    ExtendedBitmap()

    {
      Cache = new PropertyCache();
      _isNew = true;
      _isInitialised = false;
    }

    public ExtendedBitmap(Size imageSize)
    {
      Cache = new PropertyCache
      {
        Size = imageSize
      };
      Initialise();
    }

    public ExtendedBitmap(int x, int y)
    {
      Cache = new PropertyCache
      {
        Size = new Size(x, y)
      };
      Initialise();
    }

    public ExtendedBitmap(string fileName)
    {
      Cache = new PropertyCache();
      Initialise(fileName);
    }

    protected class PropertyCache
    {
      public PixelFormat BitDepth = PixelFormat.Format32bppArgb;
      public Size Size;
      Point _location;

      public Rectangle Bounds;
      public Region Clip;
      public Rectangle ClipRect;

      public void Update(ref Bitmap args)
      {
        Size = args.Size;
        _location = new Point(0, 0);
        Bounds = new Rectangle(_location, Size);
        BitDepth = args.PixelFormat;
      }

      public void Update(ref Graphics args)
      {
        if (Clip != null)
          Clip.Dispose();
        Clip = args.Clip;
        ClipRect = RectConvert(args.ClipBounds);
      }

      static Rectangle RectConvert(RectangleF iRect)

      {
        return new Rectangle((double) iRect.X <= 2147483648.0 ? ((double) iRect.X >= (double) int.MinValue ? Convert.ToInt32(iRect.X) : int.MinValue) : int.MaxValue, (double) iRect.Y <= 2147483648.0 ? ((double) iRect.Y >= (double) int.MinValue ? Convert.ToInt32(iRect.Y) : int.MinValue) : int.MaxValue, (double) iRect.Width <= 2147483648.0 ? ((double) iRect.Width >= (double) int.MinValue ? Convert.ToInt32(iRect.Width) : int.MinValue) : int.MaxValue, (double) iRect.Height <= 2147483648.0 ? ((double) iRect.Height >= (double) int.MinValue ? Convert.ToInt32(iRect.Height) : int.MinValue) : int.MaxValue);
      }
    }
  }
}
