#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
#include <time.h>

struct {
	const char *name;
	char *num;
} regMap[] = {
		{ "zero", "00000" },  // 0
		{ "at", "00001" },    // 1
		{ "v0", "00010" },    // 2
		{ "v1", "00011" },    // 3
		{ "a0", "00100" },    // 4
		{ "a1", "00101" },    // 5
		{ "a2", "00110" },    // 6
		{ "a3", "00111" },    // 7
		{ "t0", "01000" },    // 8
		{ "t1", "01001" },    // 9
		{ "t2", "01010" },    // 10
		{ "t3", "01011" },    // 11
		{ "t4", "01100" },    // 12
		{ "t5", "01101" },    // 13
		{ "t6", "01110" },    // 14
		{ "t7", "01111" },    // 15
		{ "s0", "10000" },    // 16
		{ "s1", "10001" },    // 17
		{ "s2", "10010" },    // 18
		{ "s3", "10011" },    // 19
		{ "s4", "10100" },    // 20
		{ "s5", "10101" },    // 21
		{ "s6", "10110" },    // 22
		{ "s7", "10111" },    // 23
		{ "t8", "11000" },    // 24
		{ "t9", "11001" },    // 25
		{ NULL, NULL } };

struct {
	const char *name;
	char *opcode;
	char *funct;
} instrMap[] = {
		{ "add",  "000000", "100000" },  // R-format
		{ "sub",  "000000", "100010" },  // R-format
		{ "and",  "000000", "100100" },  // R-format
		{ "or",   "000000", "100101" },  // R-format
		{ "lw",   "100011", "000000" },  // I-format (memory)
		{ "sw",   "101011", "000000" },  // I-format (memory)
		{ "andi", "001100", "000000" },  // I-format
		{ "ori",  "001101", "000000" },  // I-format
		{ "beq",  "000100", "000000" },  // I-format
		{ "addi", "001000", "000000" },  // I-format
		{ "j",    "000010", "000000" },  // J-format
		{ "jal",  "000011", "000000" },  // J-format
		{ NULL, NULL, NULL } };        
		
void assembler_R  (char *, char *, char *, char *);
void assembler_I  (char *, char *, char *, char *);
void assembler_I_M(char *, char *, char *);
void assembler_J  (char *, char *);

int main(void)
{
  char addr_mode, i_format;
  //char *mips_instr, *dest_reg, *src1_reg, *src2_reg;
  //char *mips_instr, *arg1, *arg2, *arg3;
  char mips_instr[512], arg1[512], arg2[512], arg3[512];

  //printf("%s: %s", instrMap[0].name, instrMap[0].num);
  //printf("%s: %s", regMap[0].name, regMap[0].num);

  printf("** MIPS addressing mode? [r, i, j] >> ");
  scanf("%c", &addr_mode);
  getchar();

  if (addr_mode == 'r' || addr_mode == 'R' ){
    printf("** Type R format MIPS instruction [add/sub/and/or] >> ");
    scanf("%s %s %s %s", mips_instr, arg1, arg2, arg3);
    //printf("   ==> %s %s %s %s\n", mips_instr, arg1, arg2, arg3);
    assembler_R(mips_instr, arg1, arg2, arg3);
  }
  else if (addr_mode == 'i'){
    printf("** I format MIPS instruction --> Memory operation (lw, sw)? [y, n] >> ");
    scanf("%c", &i_format);
    getchar();

    if (i_format == 'y' || i_format == 'Y'){
      printf("** Type I format - Memory MIPS instruction [lw/sw] >> ");
      scanf("%s %s %s", mips_instr, arg1, arg2);
      //printf("   ==> %s %s %s\n", mips_instr, arg1, arg2);
      assembler_I_M(mips_instr, arg1, arg2);
    }
    else{
      printf("** Type I format - Non-memory MIPS instruction [ani/ori/beq/addi] >> ");
      scanf("%s %s %s %s", mips_instr, arg1, arg2, arg3);
      //printf("   ==> %s %s %s %s\n", mips_instr, arg1, arg2, arg3);
      assembler_I(mips_instr, arg1, arg2, arg3);
    }
  }
  else if (addr_mode == 'j'){
    printf("** Type J format MIPS instruction [j/jal] >> ");
    scanf("%s %s", mips_instr, arg1);
    //printf("   ==> %s %s\n", mips_instr, arg1);
    assembler_J(mips_instr, arg1);
  }
  else {
    printf("   ==> Wrong addressing mode !!\n");
  }

}
/**
 * R-Format: [Opcode (6)] [rs (5)] [rt (5)] [rd (5)] [shamt (5)] [funct (6)]
 * Assembly: add rd, rs, rt
 */
void assembler_R(char *mips_instr, char *arg1, char *arg2, char *arg3)
{	char* op = "000000", * rs = "00000", * rt = "00000", * rd = "00000", * fn = "000000";
	printf("[Need your coding for R format] ==> %s %s %s %s\n", mips_instr, arg1, arg2, arg3);
  
  // your code here
  // 1. Find Function Code
  for (int i = 0; instrMap[i].name != NULL; i++)
	  if (strcmp(mips_instr, instrMap[i].name) == 0) fn = instrMap[i].funct;

  // 2. Map Assembly args to Machine Fields: arg1=rd, arg2=rs, arg3=rt
  for (int i = 0; regMap[i].name != NULL; i++) {
	  if (strcmp(arg1, regMap[i].name) == 0) rd = regMap[i].num;
	  if (strcmp(arg2, regMap[i].name) == 0) rs = regMap[i].num;
	  if (strcmp(arg3, regMap[i].name) == 0) rt = regMap[i].num;
  }

  printf("Result: %s %s %s %s 00000 %s\n", op, rs, rt, rd, fn);
}
/**
 * I-Format (Non-Memory): [Opcode (6)] [rs (5)] [rt (5)] [Immediate (16)]
 */
void assembler_I  (char *mips_instr, char *arg1, char *arg2, char *arg3)
{	char* op = "000000", * rs = "00000", * rt = "00000";
	int imm;

  printf("[Need your coding for I format] ==> %s %s %s %s\n", mips_instr, arg1, arg2, arg3);
  sscanf(arg3, "%d", &imm);

  printf("%s %s %s %d\n", mips_instr, arg1, arg2, imm);
   
  // your code here
  // 1. Find Function Code
  for (int i = 0; instrMap[i].name != NULL; i++)
	  if (strcmp(mips_instr, instrMap[i].name) == 0) op = instrMap[i].opcode;

  // Mapping logic: beq uses rs, rt, imm while addi/ori use rt, rs, imm
  if (strcmp(mips_instr, "beq") == 0) {
	  for (int i = 0; regMap[i].name != NULL; i++) {
		  if (strcmp(arg1, regMap[i].name) == 0) rs = regMap[i].num;
		  if (strcmp(arg2, regMap[i].name) == 0) rt = regMap[i].num;
	  }
  }
  else {
	  for (int i = 0; regMap[i].name != NULL; i++) {
		  if (strcmp(arg1, regMap[i].name) == 0) rt = regMap[i].num;
		  if (strcmp(arg2, regMap[i].name) == 0) rs = regMap[i].num;
	  }
  }

  printf("Result: %s %s %s ", op, rs, rt);
  for (int i = 15; i >= 0; i--) printf("%d", (imm >> i) & 1); // 16-bit binary loop
  printf("\n");
}
/**
 * I-Format (Memory): [Opcode (6)] [rs (5)] [rt (5)] [Offset (16)]
 * Assembly: lw rt, offset(rs)
 */
void assembler_I_M(char *mips_instr, char *arg1, char *arg2)
{	char* op = "000000", * rs = "00000", * rt = "00000";
	int offset;
	char src_reg[512];

  printf("[Need your coding for I_M format] ==> %s %s %s\n", mips_instr, arg1, arg2);
  sscanf(arg2, "%d (%[^)])", &offset, src_reg);

  printf("%s %s %d %s\n", mips_instr, arg1, offset, src_reg);
  
  // your code here
  for (int i = 0; instrMap[i].name != NULL; i++)
	  if (strcmp(mips_instr, instrMap[i].name) == 0) op = instrMap[i].opcode;

  for (int i = 0; regMap[i].name != NULL; i++) {
	  if (strcmp(arg1, regMap[i].name) == 0) rt = regMap[i].num;
	  if (strcmp(src_reg, regMap[i].name) == 0) rs = regMap[i].num;
  }

  printf("Result: %s %s %s ", op, rs, rt);
  for (int i = 15; i >= 0; i--) printf("%d", (offset >> i) & 1);
  printf("\n");

}
/**
 * J-Format: [Opcode (6)] [Target Address (26)]
 * Assembly: j target
 */
void assembler_J  (char *mips_instr, char *arg1){
  char* op = "000000";
  int t_addr;

  sscanf(arg1, "%d", &t_addr);
  printf("[Need your coding for J format] ==> %s %d\n", mips_instr, t_addr);
  
  // your code here
  // 1. Find Function Code
  for (int i = 0; instrMap[i].name != NULL; i++)
	  if (strcmp(mips_instr, instrMap[i].name) == 0) op = instrMap[i].opcode;

  // 2. Map Assembly args to Machine Fields: arg1=target address
  printf("Result: %s ", op);
  for (int i = 25; i >= 0; i--) printf("%d", (t_addr >> i) & 1); // 26-bit binary loop
  printf("\n");
}


