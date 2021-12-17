using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageRandomizer : MonoBehaviour
{
    // The sprite renderer that will display the random image
    public SpriteRenderer randomSpriteRenderer;
    
    //An array of sprites that will be used for the image randomization
    public Sprite[] randomSprites;

    //The amount of time between switching the image
    public float timeBetweenChange = 0.2f;

    //The total amount of time until randomization stops'
    public float timeUnitlStopping = 3.0f;

    //Keep track of which image is currently displaying
    private int randomImageIndex = 0;

    //How much time is left until we switch to new image
    private float imageChangeTimer;

    // Set this timer variable as soon as the script starts
    // so it's ready for the update function
    private void Start() => imageChangeTimer = timeBetweenChange;

    private void Update() {
        //Remove delta time from both active timers.
        //This subtracts a small amount of time from the 
        //overall time described in "timeBetweenChange" and "timeUntilStopping"
        imageChangeTimer -= Time.deltaTime;
        timeUnitlStopping -= Time.deltaTime;

        //If we fully run out of time we need to select a final random image
        if(timeUnitlStopping <= 0.0f) {
            //The image will be selected at random
            randomSpriteRenderer.sprite = randomSprites[Random.Range(0, randomSprites.Length)];

            //Destroy this script immediately stopping it from running anymore in the future
            DestroyImmediate(this);

            //Return so no other code runs in this Update fucntion call
            return;
        }

        // If RandomizationTimer is less than or equal to zero it's time for a new image
        if(imageChangeTimer <= 0.0f) {
            // To ensure we see all the images we increase the RandomImageIndex to see the next
            // image in the array
            randomImageIndex++;

            // If our index has gone past the end of the array, reset it to zero so the cycle
            // can start again
            if(randomImageIndex >= randomSprites.Length) {
                randomImageIndex = 0;
            }

            //Assign the new sprite to the sprite renderer
            randomSpriteRenderer.sprite = randomSprites[randomImageIndex];

            //Reset the "RandomizationTimer" to start counting down again
            imageChangeTimer = timeBetweenChange;
        }
                    
    }

}
