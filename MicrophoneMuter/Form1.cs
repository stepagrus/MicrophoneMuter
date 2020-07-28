using NAudio.Mixer;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicrophoneMuter
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);

      this.ShowInTaskbar = false;
      this.Hide();
      notifyIcon1.Visible = true;

      InitalizeMicrophoneState();
      notifyIcon1.MouseDown += NotifyIcon1_MouseDown;
    }

    private void NotifyIcon1_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;

      ChangeState();
      выходToolStripMenuItem.Text = GetRandomText();
    }

    private void InitalizeMicrophoneState()
    {
      var muter = GetMuteControl();
      _isMuted = muter.Value;
      notifyIcon1.Icon = _isMuted ? _redIco : _greenIco;
    }

    private void ChangeState()
    {
      var muter = GetMuteControl();
      muter.Value = !muter.Value;
      _isMuted = muter.Value;
      notifyIcon1.Icon = _isMuted ? _redIco : _greenIco;
    }

    private static string GetPathToIco(string icoName)
    {
      return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, icoName);
    }

    private BooleanMixerControl GetMuteControl()
    {
      var waveInEvent = new NAudio.Wave.WaveInEvent();

      //get mixer of default audio device
      var mixer = waveInEvent.GetMixerLine();
      var muter = mixer.Controls.FirstOrDefault(x => x.ControlType == NAudio.Mixer.MixerControlType.Mute) as BooleanMixerControl;
      if (muter == null)
        throw new Exception("Микрофон не поддерживает фунцию Mute");

      return muter;
    }

    private void выходToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private string GetRandomText()
    {
      var r = new Random();
      switch (r.Next(0, 5))
      {
        case 0: return "Выход";
        case 1: return "Закрыть";
        case 2: return "Ивешвара - молодец";
        case 3: return "Ты сегодня внимательно медитировал?";
        case 4: return "Крепче повторяй Харе Кришна!";
        default: return "Досвидания";
      }
    }

    private const string RedIcoName = "red32.ico";
    private const string GreenIcoName = "green32.ico";

    private bool _isMuted = false;
    private readonly Icon _redIco = Icon.ExtractAssociatedIcon(GetPathToIco(RedIcoName));
    private readonly Icon _greenIco = Icon.ExtractAssociatedIcon(GetPathToIco(GreenIcoName));
  }
}
