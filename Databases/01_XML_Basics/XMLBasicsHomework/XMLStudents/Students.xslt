<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt"
                exclude-result-prefixes="msxsl"
                xmlns:mine="urn:students">
  <xsl:output method="html" indent="yes"/>

  <xsl:template match="/mine:university">
    <html>
      <head>
        <tytle>Homework XML</tytle>
      </head>
      <body>
        <h1>Students</h1>
        <table border="1px">
          <tr>
            <th>Name</th>
            <th>Gender</th>
            <th>Birth date</th>
            <th>Phone</th>
            <th>Email</th>
            <th>Course</th>
            <th>Specialty</th>
            <th>Faculty number</th>
          </tr>
          <xsl:for-each select="mine:students/mine:student">
            <tr>
              <td>
                <xsl:value-of select="mine:name"></xsl:value-of>
              </td>
              <td>
                <xsl:value-of select="mine:gender"></xsl:value-of>
              </td>
              <td>
                <xsl:value-of select="mine:birthDate"></xsl:value-of>
              </td>
              <td>
                <xsl:value-of select="mine:phone"></xsl:value-of>
              </td>
              <td>
                <xsl:value-of select="mine:emali"></xsl:value-of>
              </td>
              <td>
                <xsl:value-of select="mine:course"></xsl:value-of>
              </td>
              <td>
                <xsl:value-of select="mine:specialty"></xsl:value-of>
              </td>
              <td>
                <xsl:value-of select="mine:facultyNumber"></xsl:value-of>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
