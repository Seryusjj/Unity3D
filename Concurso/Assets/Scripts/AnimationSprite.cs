using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimationSprite
{


    private int columnSize;
    private int rowSize;
    private int colFrameStart;
    private int rowFrameStart;
    private int totalFrames;
    private float framesPerSecond;



    public AnimationSprite(int columnSize, int rowSize, int colFrameStart, int rowFrameStart, int totalFrames, float framesPerSecond)
    {
        this.columnSize = columnSize;
        this.rowSize = rowSize;
        this.colFrameStart = colFrameStart;
        this.rowFrameStart = rowFrameStart;
        this.totalFrames = totalFrames;
        this.framesPerSecond = framesPerSecond;

    }

    public void AnimateWithNormalMap(GameObject spriteObject, float gameTime)
    {
        int index = (int)(gameTime * framesPerSecond);
        index = index % totalFrames;

        Vector2 size = new Vector2(1.0F / columnSize, 1.0F / rowSize);

        int u = index % columnSize;
        int v = index / columnSize;


        Vector2 offset = new Vector2((u + colFrameStart) * size.x, (1 - size.y) - ((v + rowFrameStart) * size.y));

        spriteObject.renderer.material.mainTextureOffset = offset;
        spriteObject.renderer.material.mainTextureScale = size;

        spriteObject.renderer.material.SetTextureOffset("_BumpMap", offset);
        spriteObject.renderer.material.SetTextureScale("_BumpMap", size);
    }

    public void Animate(GameObject spriteObject, float gameTime)
    {
        int index = (int)(gameTime * framesPerSecond);
        index = index % totalFrames;

        Vector2 size = new Vector2(1.0F / columnSize, 1.0F / rowSize);

        int u = index % columnSize;
        int v = index / columnSize;

        Vector2 offset = new Vector2((u + colFrameStart) * size.x, (1 - size.y) - ((v + rowFrameStart) * size.y));

        spriteObject.renderer.material.mainTextureOffset = offset;
        spriteObject.renderer.material.mainTextureScale = size;
    }












    public void AnimateFont(GameObject spriteObject, float gameTime, string type)
    {
        int index = CalculateFontIndex(gameTime, type);

        Vector2 size = new Vector2(1.0F / columnSize, 1.0F / rowSize);

        int u = index % columnSize;
        int v = index / columnSize;

        Vector2 offset = new Vector2((u + colFrameStart) * size.x, (1 - size.y) - ((v + rowFrameStart) * size.y));

        spriteObject.renderer.material.mainTextureOffset = offset;
        spriteObject.renderer.material.mainTextureScale = size;
    }

    private int CalculateFontIndex(float gameTime, string type)
    {
        int index = (int)(gameTime);


        var font1 = index % 10;
        var font2 = ((index - font1) / 10) % 10;
        var font3 = ((index - font2) / 100) % 10;
        var font4 = ((index - font3) / 1000) % 10;

        if (type.Equals("font1")) index = font1;
        else if (type.Equals("font2")) index = font2;
        else if (type.Equals("font3")) index = font3;
        else if (type.Equals("font4")) index = font4;

        return index;
    }


    public AnimationSprite SetColumnSize(int columnSize)
    {
        this.columnSize = columnSize;
        return this;
    }
    public AnimationSprite SetRowSize(int rowSize)
    {
        this.rowSize = rowSize;
        return this;
    }

    public AnimationSprite SetTotalFrames(int totalFrames)
    {
        this.totalFrames = totalFrames;
        return this;
    }

    public AnimationSprite SetFramesPerSecond(int framesPerSecond)
    {
        this.framesPerSecond = framesPerSecond;
        return this;
    }

    public AnimationSprite SetRowFrameStart(int rowFrameStart)
    {
        this.rowFrameStart = rowFrameStart;
        return this;
    }


    public AnimationSprite SetColFrameStart(int colFrameStart)
    {
        this.colFrameStart = colFrameStart;
        return this;
    }




}
