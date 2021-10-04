package com.example.lab5;

import javax.imageio.ImageIO;
import java.awt.image.BufferedImage;
import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.IOException;
import java.nio.file.FileSystems;
import java.util.ArrayList;
import java.util.Base64;

public class ImageService {
    private final String carCategoryName = "cars";
    private final String motorcycleCategoryName = "motorcycles";
    private final String flowerCategoryName = "flowers";
    private ArrayList<String> images;
    private static final int BUFFER_SIZE = 8192;

    public ArrayList<String> getImagesByCategory(String categoryName) throws IOException {
        images = new ArrayList<String>();

        if (carCategoryName.contains(categoryName)) {
            images.add(imageToBase64(ImageIO.read(new File("img\\car1.jpg"))));
            images.add(imageToBase64(ImageIO.read(new File("img\\car2.jpg"))));
            images.add(imageToBase64(ImageIO.read(new File("img\\car3.jpg"))));
            images.add(imageToBase64(ImageIO.read(new File("img\\car4.jpg"))));
        }

        if (motorcycleCategoryName.contains(categoryName)) {
            images.add(imageToBase64(ImageIO.read(new File("img\\moto1.jpg"))));
            images.add(imageToBase64(ImageIO.read(new File("img\\moto2.jpg"))));
            images.add(imageToBase64(ImageIO.read(new File("img\\moto3.jpg"))));
        }

        if (flowerCategoryName.contains(categoryName)) {
            images.add(imageToBase64(ImageIO.read(new File("img\\flower1.jpg"))));
            images.add(imageToBase64(ImageIO.read(new File("img\\flower2.jpg"))));
            images.add(imageToBase64(ImageIO.read(new File("img\\flower3.jpg"))));
            images.add(imageToBase64(ImageIO.read(new File("img\\flower4.jpg"))));
        }

        return images;
    }

    public static String imageToBase64(BufferedImage image) throws IOException {
        ByteArrayOutputStream out = new ByteArrayOutputStream(BUFFER_SIZE);
        ImageIO.write(image, "jpg", out);
        return Base64.getEncoder().encodeToString(out.toByteArray());
    }
}
