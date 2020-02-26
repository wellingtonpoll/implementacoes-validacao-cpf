package main

import (
	"fmt"
	"time"
)

func main() {

	start := time.Now()
	interations := 1000000

	for i := 0; i < interations; i++ {

		newCPF("529.982.247-25")
	}

	duration := time.Now().Sub(start).Milliseconds()
	fmt.Printf("Executed %d in %d miliseconds \n", interations, duration)
}
