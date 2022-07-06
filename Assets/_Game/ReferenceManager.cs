using UnityEngine;
using Aezakmi.Tweens;

namespace Aezakmi
{
    public enum CaseType { Normal, Pokemon, }

    public class ReferenceManager : GloballyAccessibleBase<ReferenceManager>
    {
        public MoveToPosition CurrentCase { get; private set; }
        public GameObject CurrentCaseUpper { get; private set; }
        public GameObject CurrentEarbuds { get; private set; }
        public GameObject CurrentEarbudLeft { get; private set; }
        public GameObject CurrentEarbudRight { get; private set; }
        public GameObject CurrentEarbudLeftSilicone { get; private set; }
        public GameObject CurrentEarbudRightSilicone { get; private set; }

        public CaseType CurrentCaseType { get; private set; }

        [Header("Normal")]
        [SerializeField] private MoveToPosition _normalCase;
        [SerializeField] private GameObject _normalCaseUpper;
        [SerializeField] private GameObject _normalEarbuds;
        [SerializeField] private GameObject _normalEarbudLeft;
        [SerializeField] private GameObject _normalEarbudRight;
        [SerializeField] private GameObject _normalEarbudLeftSilicone;
        [SerializeField] private GameObject _normalEarbudRightSilicone;

        [Header("Pokemon")]
        [SerializeField] private MoveToPosition _pokemonCase;
        [SerializeField] private GameObject _pokemonCaseUpper;
        [SerializeField] private GameObject _pokemonEarbuds;
        [SerializeField] private GameObject _pokemonEarbudLeft;
        [SerializeField] private GameObject _pokemonEarbudRight;
        [SerializeField] private GameObject _pokemonEarbudLeftSilicone;
        [SerializeField] private GameObject _pokemonEarbudRightSilicone;

        protected override void Awake()
        {
            base.Awake();

            CurrentCaseType = (CaseType)(GlobalData.roundsCount % 2);
            
            // // TEMPPPPPPPPPPPPP
            // CurrentCaseType = CaseType.Pokemon;
            // // TEMPPPPPPPPPPPPP

            if (CurrentCaseType == CaseType.Normal)
            {
                CurrentCase = _normalCase;
                CurrentCaseUpper = _normalCaseUpper;
                CurrentEarbuds = _normalEarbuds;
                CurrentEarbudLeft = _normalEarbudLeft;
                CurrentEarbudRight = _normalEarbudRight;
                CurrentEarbudLeftSilicone = _normalEarbudLeftSilicone;
                CurrentEarbudRightSilicone = _normalEarbudRightSilicone;
            }
            else if (CurrentCaseType == CaseType.Pokemon)
            {
                CurrentCase = _pokemonCase;
                CurrentCaseUpper = _pokemonCaseUpper;
                CurrentEarbuds = _pokemonEarbuds;
                CurrentEarbudLeft = _pokemonEarbudLeft;
                CurrentEarbudRight = _pokemonEarbudRight;
                CurrentEarbudLeftSilicone = _pokemonEarbudLeftSilicone;
                CurrentEarbudRightSilicone = _pokemonEarbudRightSilicone;
            }

            DisableAll();

            CurrentCase.gameObject.SetActive(true);
        }

        private void DisableAll()
        {
            _normalCase.gameObject.SetActive(false);
            _normalEarbuds.gameObject.SetActive(false);

            _pokemonCase.gameObject.SetActive(false);
            _pokemonEarbuds.gameObject.SetActive(false);
        }
    }
}
