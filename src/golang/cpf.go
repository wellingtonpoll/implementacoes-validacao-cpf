package main

import (
	"strings"
	"unicode"
)

// CPF estrutura básica
type CPF struct {
	value   string
	isValid bool
}

func newCPF(number string) CPF {

	number = strings.ReplaceAll(strings.ReplaceAll(number, ".", ""), "-", "")

	cpf := CPF{value: number, isValid: false}

	if len(number) != 11 {
		cpf.isValid = false
		return cpf
	}

	posicao := 0
	totalDigito1 := 0
	totalDigito2 := 0
	dv1 := 0
	dv2 := 0

	digitosIdenticos := false
	ultimoDigito := -1

	for pos, char := range number {
		if unicode.IsDigit(char) {
			digito := pos - '0'
			if pos != 0 && ultimoDigito != digito {
				digitosIdenticos = false
			}
			ultimoDigito = digito
			if pos < 9 {
				totalDigito1 += digito * (10 - pos)
				totalDigito2 += digito * (11 - pos)
			} else if posicao == 9 {
				dv1 = digito
			} else if posicao == 10 {
				dv2 = digito
			}
			posicao++
		}
	}

	if posicao > 11 || digitosIdenticos {
		cpf.isValid = false
		return cpf
	}

	digito1 := mod11(totalDigito1 % 11)

	if dv1 != digito1 {
		cpf.isValid = false
		return cpf
	}

	digito2 := mod11((totalDigito2 + digito1*2) % 11)

	cpf.isValid = dv2 == digito2
	return cpf
}

func mod11(digito int) int {
	if digito < 2 {
		digito = 0
	} else {
		digito = 11 - digito
	}
	return digito
}
