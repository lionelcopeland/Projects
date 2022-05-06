#BMI Calculator

name = input("Please enter your name here: ")
height = input("Please enter your height in meters:")
weight = input("Please enter your weight in kg: ")

bmi = int(weight) / float(height) ** 2

bmi_convert = int(bmi)

print (bmi_convert)

if bmi_convert < 25:
	print(name)
	print("is not overweight")

else:
	print(name)
	print("is overweight")
