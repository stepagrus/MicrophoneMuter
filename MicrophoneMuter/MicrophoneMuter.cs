using NAudio.Mixer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace MicrophoneMuter
{
  class MicrophoneMuter : IDisposable
  {
    public MicrophoneMuter()
    {
      _timer = new Timer();
      _timer.Tick += OnTick;
      _timer.Interval = 200;
    }

    public void Dispose()
    {
      _timer.Dispose();
    }

    public void Start()
    {
      Refresh();
      _timer.Start();
    }

    public void ChangeToOpposite()
    {
      try
      {
        _muteControl.Value = !_muteControl.Value;

        var oldState = _isMuted;
        _isMuted = _muteControl.Value;

        if (oldState != _isMuted)
          MutedChanged?.Invoke(this, _isMuted.Value);
      }
      catch
      {
        //no actions required
      }
    }

    /// <summary>
    /// true = muted. false = unmuted, null = unknown.
    /// </summary>
    public event EventHandler<bool?> MutedChanged;

    public event EventHandler<string> ErrorChanged;


    private void OnTick(object sender, EventArgs e)
    {
      try
      {
        GetMicrophoneState();
      }
      catch
      {
        Refresh();
      }
    }

    private void Refresh()
    {
      try
      {
        _muteControl = GetMuteControl();
        GetMicrophoneState();
      }
      catch (Exception ex)
      {
        if (_lastError != ex.Message)
        {
          _lastError = ex.Message;
          ErrorChanged?.Invoke(this, _lastError);
        }

        var oldState = _isMuted;
        _isMuted = null;
        if (oldState != _isMuted)
          MutedChanged?.Invoke(this, null);
      }
    }

    private void GetMicrophoneState()
    {
      var oldState = _isMuted;
      _isMuted = _muteControl.Value;
      if (oldState != _isMuted)
        MutedChanged?.Invoke(this, _isMuted);
    }

    private BooleanMixerControl GetMuteControl()
    {
      var waveInEvent = new NAudio.Wave.WaveInEvent();

      //get mixer of default audio device
      var mixer = waveInEvent.GetMixerLine();
      var muter = mixer.Controls.FirstOrDefault(x => x.ControlType == NAudio.Mixer.MixerControlType.Mute) as BooleanMixerControl;
      if (muter == null)
        throw new Exception(BadMicrophoneMessage);

      return muter;
    }

    private readonly Timer _timer = new System.Windows.Forms.Timer();
    private BooleanMixerControl _muteControl;

    private bool? _isMuted;
    private string _lastError;


    private const string BadMicrophoneMessage = "Микрофон не поддерживает фунцию Mute";
  }
}
