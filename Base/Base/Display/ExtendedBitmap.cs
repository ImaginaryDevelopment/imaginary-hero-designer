
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

    protected ExtendedBitmap.PropertyCache Cache;
    bool _isNew;

    bool _isInitialised;


    public Graphics Graphics
    {
      get
      {
        Graphics graphics;
        if (this._isInitialised)
        {
          this._isNew = false;
          graphics = this._surface;
        }
        else if (this.Initialise())
        {
          this._isNew = false;
          graphics = this._surface;
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
        return !this._isInitialised ? (this.Initialise() ? this._bits : null) : this._bits;
      }
    }

    bool CanInitialise

    {
      get
      {
        bool flag;
        if (this._isDisposed)
          flag = false;
        else if (this.Cache.Size.Width > 0 & this.Cache.Size.Height > 0)
          flag = true;
        else if (this.Cache.Bounds.Width > 0 & this.Cache.Bounds.Height > 0)
        {
          this.Cache.Size.Width = this.Cache.Bounds.Width;
          this.Cache.Size.Height = this.Cache.Bounds.Height;
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
        return this._isInitialised ? this.Cache.Size : new Size();
      }
      set
      {
        if (value.Width == this.Cache.Size.Width && value.Height == this.Cache.Size.Height)
          return;
        this.Cache.Size = value;
        this.Initialise();
      }
    }

    Region Clip

    {
      get
      {
        return this._isInitialised ? this.Cache.Clip : new Region();
      }
      set
      {
        if (!this._isInitialised)
          return;
        this._surface.Clip = value;
        this.Cache.Update(ref this._surface);
        this._isNew = false;
      }
    }

    public Rectangle ClipRect
    {
      get
      {
        return this._isInitialised ? this.Cache.ClipRect : new Rectangle();
      }
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!disposing || this._isDisposed)
        return;
      this._isNew = false;
      this._isInitialised = false;
      if (this._surface != null)
        this._surface.Dispose();
      if (this._bits != null)
        this._bits.Dispose();
      if (this.Cache.Clip != null)
        this.Cache.Clip.Dispose();
      this._isDisposed = true;
    }

    public object Clone()
    {
      object obj;
      if (!this._isInitialised)
      {
        obj = (object) new ExtendedBitmap();
      }
      else
      {
        ExtendedBitmap extendedBitmap = new ExtendedBitmap(this.Size)
        {
          Cache = this.Cache
        };
        extendedBitmap._surface.DrawImageUnscaled((Image) this._bits, new Point(0, 0));
        extendedBitmap.Clip = this.Clip;
        extendedBitmap._isInitialised = this._isInitialised;
        extendedBitmap._isNew = this._isNew;
        obj = (object) extendedBitmap;
      }
      return obj;
    }

    bool Initialise()

    {
      bool flag;
      if (!this.CanInitialise)
      {
        flag = false;
      }
      else
      {
        if (this._surface != null)
          this._surface.Dispose();
        if (this._bits != null)
          this._bits.Dispose();
        this._bits = new Bitmap(this.Cache.Size.Width, this.Cache.Size.Height, this.Cache.BitDepth);
        this._surface = Graphics.FromImage((Image) this._bits);
        this.Cache.Update(ref this._bits);
        this._surface.Clip = new Region(this.Cache.Bounds);
        this.Cache.Update(ref this._surface);
        this._isNew = true;
        this._isInitialised = true;
        flag = true;
      }
      return flag;
    }

    void Initialise(string fileName)

    {
      if (this._surface != null)
        this._surface.Dispose();
      if (this._bits != null)
        this._bits.Dispose();
      if (!File.Exists(fileName))
      {
        this.Cache = new ExtendedBitmap.PropertyCache()
        {
          Size = new Size(32, 32)
        };
        this.Initialise();
      }
      else
      {
        this._bits = new Bitmap(fileName);
        this._surface = Graphics.FromImage((Image) this._bits);
        this.Cache.Update(ref this._bits);
        this._surface.Clip = new Region(this.Cache.Bounds);
        this.Cache.Update(ref this._surface);
        this._isNew = true;
        this._isInitialised = true;
      }
    }

    ExtendedBitmap()

    {
      this.Cache = new ExtendedBitmap.PropertyCache();
      this._isNew = true;
      this._isInitialised = false;
    }

    public ExtendedBitmap(Size imageSize)
    {
      this.Cache = new ExtendedBitmap.PropertyCache()
      {
        Size = imageSize
      };
      this.Initialise();
    }

    public ExtendedBitmap(int x, int y)
    {
      this.Cache = new ExtendedBitmap.PropertyCache()
      {
        Size = new Size(x, y)
      };
      this.Initialise();
    }

    public ExtendedBitmap(string fileName)
    {
      this.Cache = new ExtendedBitmap.PropertyCache();
      this.Initialise(fileName);
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
        this.Size = args.Size;
        this._location = new Point(0, 0);
        this.Bounds = new Rectangle(this._location, this.Size);
        this.BitDepth = args.PixelFormat;
      }

      public void Update(ref Graphics args)
      {
        if (this.Clip != null)
          this.Clip.Dispose();
        this.Clip = args.Clip;
        this.ClipRect = ExtendedBitmap.PropertyCache.RectConvert(args.ClipBounds);
      }

      static Rectangle RectConvert(RectangleF iRect)

      {
        return new Rectangle((double) iRect.X <= 2147483648.0 ? ((double) iRect.X >= (double) int.MinValue ? Convert.ToInt32(iRect.X) : int.MinValue) : int.MaxValue, (double) iRect.Y <= 2147483648.0 ? ((double) iRect.Y >= (double) int.MinValue ? Convert.ToInt32(iRect.Y) : int.MinValue) : int.MaxValue, (double) iRect.Width <= 2147483648.0 ? ((double) iRect.Width >= (double) int.MinValue ? Convert.ToInt32(iRect.Width) : int.MinValue) : int.MaxValue, (double) iRect.Height <= 2147483648.0 ? ((double) iRect.Height >= (double) int.MinValue ? Convert.ToInt32(iRect.Height) : int.MinValue) : int.MaxValue);
      }
    }
  }
}
