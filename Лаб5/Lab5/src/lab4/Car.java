/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package lab4;

import java.beans.*;
import java.io.Serializable;

/**
 *
 * @author zimin
 */
public class Car implements Serializable {
    
    private String name;
    private boolean deceased;
    private int maxSpeed, curSpeed;
    
    public Car() {
        name = "Default name";
        maxSpeed = 500;
        curSpeed = 0;
    }
    
    // Методы геттеры (get) и сеттеры (set)
    public String getName() {
        return name;
    }
    
    public void setName(String name) {
        this.name = name;
    }
    
    public int getMaxSpeed() {
        return maxSpeed;
    }
    
    public int getCurSpeed() {
        return curSpeed;
    }
    
    public void setMaxSpeed(int maxSpeed) {
        this.maxSpeed = maxSpeed;
    }
    
    public boolean isDeceased() {
        return deceased;
    }
    
    public void setDeceased(boolean deceased) {
        this.deceased = deceased;
    }
    
    public void SpeedUp() {
        curSpeed += 10;
    }
    
    //Переопределенные методы equals() и hashCode()
    @Override
    public boolean equals(Object o) {
        if (this == o) {
            return true;
        }
        if (o == null || getClass() != o.getClass()) {
            return false;
        }

        Car that = (Car) o;

        if (deceased != that.deceased) {
            return false;
        }
        return !(name != null ? !name.equals(that.name) : that.name != null);
    }

    @Override
    public int hashCode() {
        int result = name != null ? name.hashCode() : 0;
        result = 31 * result + (deceased ? 1 : 0);
        return result;
    }

    //Переопределенный метод6 toString()
    @Override
    public String toString() {
        return "name = '" + name + '\'' + 
                "\nmaxSpeed = " + maxSpeed +
                "\ndeceased = " + deceased;
    }   
}
