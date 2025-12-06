import math
import sys

def ellipse_dimension(a):
    e = 0.0167 # eccentricity
    c = e * a # focal distance
    b = math.sqrt(a**2 - c**2) # "height"
    return b