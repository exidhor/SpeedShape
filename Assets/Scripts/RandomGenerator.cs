using UnityEngine;
using System.Collections;
using System;

public class RandomGenerator : MonoBehaviour
{
    public bool generateNewSeed = true;
    public int seed;

    private System.Random m_PseudoRandom;

    /*!
    * \brief   TODO
    */
    void Awake()
    {

    }

    /*!
    * \brief   TODO
    */
    void Start()
    {
        Generate();
    }

    /*!
        * \brief Construct the Random Number Generator
        */
    public void Generate()
    {
        if (generateNewSeed)
        {
            seed = GenerateSeed();
        }
        m_PseudoRandom = new System.Random(seed);
    }

    /*!
        * \brief Generate a new seed using the current time 
        * \return seed 
        */
    private int GenerateSeed()
    {
        DateTime t_CurrentTime = DateTime.Now;
        return t_CurrentTime.Ticks.ToString().GetHashCode();
    }

    /*!
        * \brief Get a random value in the interval chosen
        * \param a_MinValue the boundary start of the interval
        * \param a_MinValue the boundary end of the interval
        * \return random value
        */
    public int Next(int a_MinValue, int a_MaxValue)
    {
        return m_PseudoRandom.Next(a_MinValue, a_MaxValue);
    }

    /*!
        * \brief   Get uniformly a random boolean
        * \return  True of False, with same probability (in theory)
        */
    public bool NextBool()
    {
        if (m_PseudoRandom.Next(0, 2) == 1)
            return true;

        return false;
    }
}
