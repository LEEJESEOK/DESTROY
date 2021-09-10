using UnityEngine;
using Random = System.Random;

namespace Project.Scripts.Fractures
{
    public class FractureThis
    {
        [SerializeField] private Anchor anchor = Anchor.None;
        [SerializeField] private int chunks = 10;
        [SerializeField] private float density = 50;
        [SerializeField] private float internalStrength = 100;

        private Material insideMaterial;
        private Material outsideMaterial;

        private Random rng = new Random();

        public GameObject fractureObj;

        private static FractureThis Instance;

        public static FractureThis GetInstance()
        {
            if (Instance == null)
            {
                Instance = new FractureThis();

            }

            return Instance;
        }

        public GameObject CreateFracture(GameObject gameObject)
        {
            //���⼭ ���׸��� �����ּ�

            GameObject fractureObj = FractureGameobject(gameObject).fractureObj;
            fractureObj.SetActive(false);
            return fractureObj;
        }

        public ChunkGraphManager FractureGameobject(GameObject gameObject)
        {
            var seed = rng.Next();
            
            insideMaterial = GameManager.instance.fractureMat;
            outsideMaterial = GameManager.instance.fractureMat;
            
            return Fracture.FractureGameObject(
                gameObject,
                anchor,
                seed,
                chunks,
                insideMaterial,
                outsideMaterial,
                internalStrength,
                density
            );
        }

       
    }
}