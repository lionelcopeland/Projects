#BMI Calculator

import random

name = input("Enter your name: ")
weight_kg = input("Enter weight in kilograms: ")
height_m = input("Enter Height in meters: ")




BMI = weight_kg / (height_m * height_m)
print("BMI: ")
print (BMI)
if BMI < 25:
	print(name)
	print("is not overweight")
else:
	print(name)
	print("is overweight")