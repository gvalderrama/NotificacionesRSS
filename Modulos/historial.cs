using System;

namespace ventanas
{
	public partial class historial : Gtk.Window
	{
		public historial () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}

		protected void OnButton9Clicked (object sender, EventArgs e)
		{
			new ventanas.MainClass();
			//throw new System.NotImplementedException ();
		}
	}
}

