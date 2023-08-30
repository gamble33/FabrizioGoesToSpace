using System.Collections;

namespace Fabrizio.Audio
{
    public class AudioController : UnityEngine.MonoBehaviour
    {
        [System.Serializable]
        public struct AudioObject
        {
            public AudioKind kind;
            public UnityEngine.AudioClip clip;
        }

        [System.Serializable]
        public struct AudioTrack
        {
            public UnityEngine.AudioSource source;
            public AudioObject[] audio;
        }

        private struct AudioJob
        {
            public readonly AudioAction Action;
            public readonly AudioKind Kind;

            public AudioJob(AudioAction action, AudioKind kind)
            {
                Action = action;
                Kind = kind;
            }
        }

        private enum AudioAction
        {
            Start,
            Stop,
            Restart
        }

        public static AudioController Instance;
        public bool debug;
        public AudioTrack[] tracks;

        private Hashtable _audioTable;
        private Hashtable _jobTable;

        public void PlayAudio(AudioKind kind)
        {
            AddJob(new AudioJob(AudioAction.Start, kind));
        }

        public void StopAudio(AudioKind kind)
        {
            AddJob(new AudioJob(AudioAction.Stop, kind));
        }

        public void RestartAudio(AudioKind kind)
        {
            AddJob(new AudioJob(AudioAction.Restart, kind));
        }

        private IEnumerator RunAudioJob(AudioJob job)
        {
            AudioTrack track = (AudioTrack)_audioTable[job.Kind];
            track.source.clip = GetAudioClipFromAudioTrack(job.Kind, track);

            switch (job.Action)
            {
                case AudioAction.Start:
                    track.source.Play();
                    break;

                case AudioAction.Stop:
                    track.source.Stop();
                    break;

                case AudioAction.Restart:
                    track.source.Stop();
                    track.source.Play();
                    break;
            }
            
            _jobTable.Remove(job.Kind);
            yield return null;
        }

        public UnityEngine.AudioClip GetAudioClipFromAudioTrack(AudioKind kind, AudioTrack track)
        {
            foreach (AudioObject audioObject in track.audio)
            {
                if (audioObject.kind == kind)
                    return audioObject.clip;
            }

            return null;
        }

        private void AddJob(AudioJob job)
        {
            RemoveConflictingJobs(job.Kind);
            IEnumerator jobRunner = RunAudioJob(job);
            _jobTable.Add(job.Kind, jobRunner);
            StartCoroutine(jobRunner);
        }

        private void RemoveJob(AudioKind kind)
        {
            if (!_jobTable.ContainsKey(kind))
            {
                LogWarning("Attempted to remove job " + kind + " that is not being executed.");
                return;
            }

            IEnumerator runningJob = (IEnumerator)_jobTable[kind];
            StopCoroutine(runningJob);
            _jobTable.Remove(kind);
        }

        private void RemoveConflictingJobs(AudioKind kind)
        {
            if (_jobTable.ContainsKey(kind))
            {
                RemoveConflictingJobs(kind);
            }

            AudioKind conflictingAudio = AudioKind.None;
            foreach (DictionaryEntry entry in _jobTable)
            {
                AudioKind audioKind = (AudioKind)entry.Key;
                AudioTrack audioTrackInUse = (AudioTrack)_audioTable[audioKind];
                AudioTrack audioTrackNeeded = (AudioTrack)_audioTable[kind];

                if (audioTrackNeeded.source == audioTrackInUse.source)
                {
                    conflictingAudio = audioKind;
                }

                if (conflictingAudio != AudioKind.None)
                {
                    RemoveConflictingJobs(conflictingAudio);
                }
            }
        }

        private void GenerateAudioTable()
        {
            foreach (AudioTrack track in tracks)
            {
                foreach (AudioObject audioObject in track.audio)
                {
                    if (_audioTable.ContainsKey(audioObject.kind))
                    {
                        LogWarning("Audio (" + audioObject.kind + ") is being registered twice.");
                    }
                    else
                    {
                        _audioTable.Add(audioObject.kind, track);
                    }
                }
            }
        }

        private void Configure()
        {
            Instance = this;
            _audioTable = new Hashtable();
            _jobTable = new Hashtable();
            GenerateAudioTable();
        }

        private void Dispose()
        {
            foreach (DictionaryEntry entry in _jobTable)
            {
                IEnumerator job = (IEnumerator)entry.Value;
                StopCoroutine(job);
            }
        }

        private void Awake()
        {
            if (!Instance)
            {
                Configure();
            }
        }

        private void OnDisable()
        {
            Dispose();
        }

        #region Debug

        private void Log(string msg)
        {
            if (!debug) return;
            UnityEngine.Debug.Log("[AudioController]: " + msg);
        }

        private void LogWarning(string msg)
        {
            if (!debug) return;
            UnityEngine.Debug.LogWarning("[AudioController]: " + msg);
        }

        #endregion
    }
}