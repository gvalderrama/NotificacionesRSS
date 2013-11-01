using System;

namespace ventanas
{
	public partial class ajustes : Gtk.Window
	{
		public ajustes () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}

		protected void OnButton11Clicked (object sender, EventArgs e)
		{
			//throw new System.NotImplementedException ();
		}

		protected void OnButton10Clicked (object sender, EventArgs e)
		{
			new ventanas.MainClass();
			//throw new System.NotImplementedException ();
		}
	}
}

