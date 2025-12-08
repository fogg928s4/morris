import math
import sys


def calc_ellipse_height(a):
    e = 0.0167 # eccentricity
    c = e * a # focal distance
    b = math.sqrt(a**2 - c**2) # "height"
    return b

def calc_dist_Star(x, a, c): # x coordinate
    temp = (x/a)**2
    b =  calc_ellipse_height(a)
    y =  math.sqrt(1 - temp) * b **2
    dSqr = ((c-y)**2) + x**2
    return dSqr